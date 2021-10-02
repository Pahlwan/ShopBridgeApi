using Microsoft.AspNetCore.Mvc;
using Repository;
using ShopBridgeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBridgeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public ItemController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<ItemController>
        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {
            var items =  _unitOfWork.Items.GetAll();
            if(items == null)
            {
                return NotFound();
            }

            return Ok(items);
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            var item = _unitOfWork.Items.Get(id);
            if(item == null)
            {
                return NotFound();
            }
            _unitOfWork.Complete(item);
            return Ok(item);

        }

        // POST api/<ItemController>
        [HttpPost]
        public ActionResult<string> Post([FromBody] Item item)
        {
            try
            {
                _unitOfWork.Items.Add(item);
                _unitOfWork.Complete(item);
                
                return Ok($"[OK] Item with id {item.Id} to database.");
            }
            catch(Exception ex)
            {
                return BadRequest($"[ERROR] Bad request.\n\t{ex.Message}");
            }
        }

        [HttpPut]
        public ActionResult<string> Put([FromBody] Item item)
        {
            try
            {
                _unitOfWork.Items.Update(item);
                _unitOfWork.Complete(item);

                return Ok($"[OK] Item Updated id { item.Id} to database.");
            }
            catch (Exception ex)
            {
                return BadRequest($"[ERROR] Requested Id not present in database.\n\t{ex.Message}");
            }
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                Item item = _unitOfWork.Items.Get(id);
                _unitOfWork.Items.Remove(item);
                _unitOfWork.Complete(item);

                return Ok($"[OK] Item deleted from database with id {item.Id}");
            }
            catch(Exception ex)
            {
                return BadRequest($"[ERROR] Requested Id not present in database.\n\t{ex.Message}");
            }
        }
    }
}

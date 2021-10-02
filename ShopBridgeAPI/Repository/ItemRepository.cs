using Microsoft.EntityFrameworkCore;
using ShopBridgeAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ItemRepository : Repository<Item>,IItemRepository
    {
        public ItemRepository(PlutoContext context):base(context)
        {

        }


        public PlutoContext PlutoContext { get { return Context as PlutoContext; } }

        public Item GetItemByName(string name)
        {
            return PlutoContext.Items.Where(item => item.Name == name).FirstOrDefault();
        }

        public IEnumerable<Item> GetItemsByPrice(decimal price)
        {
            return PlutoContext.Items.Where(item => item.Price < price);
        }
    }
}

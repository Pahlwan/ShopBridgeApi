
using ShopBridgeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IItemRepository:IRepository<Item> 
    {
        Item GetItemByName(string name);
        IEnumerable<Item> GetItemsByPrice(decimal price);
    }
}

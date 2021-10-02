
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ShopBridgeAPI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace Tests
{
    [TestClass]
    public class UnitTestItemController
    {
        [TestMethod]
        public  void Tests()
        {
            
            var client = new HttpClient { BaseAddress = new Uri("http://localhost:5000/api/Item") };
            //Addition test
            StringContent content = new StringContent(JsonConvert.SerializeObject(new Item() { Id = 5, Name = "Oil y",Price = 23,Discription = "df",ImageUrl = "" }), Encoding.UTF8, "application/json");
            HttpResponseMessage addResponse = client.PostAsync($"/api/item", content).Result;
            Assert.IsNotNull(addResponse);
            Assert.IsTrue(addResponse.StatusCode == System.Net.HttpStatusCode.OK);

            //GetAll TSest
            HttpResponseMessage getAllResponse = client.GetAsync("/api/Item").Result;
            Assert.IsNotNull(getAllResponse);
            Assert.IsTrue(getAllResponse.StatusCode == System.Net.HttpStatusCode.OK);
            Task<string> task = getAllResponse.Content.ReadAsStringAsync();
            int count = 0;
            List<Item> items = JsonConvert.DeserializeObject<IEnumerable<Item>>(task.Result).ToList();
            foreach (var item in items)
            {
                Assert.IsTrue(item.Id !=0);

                //GetbyId Test
                HttpResponseMessage getByIdResponse = client.GetAsync($"/api/item/{item.Id}").Result;
                Assert.IsNotNull(getByIdResponse);
                Assert.IsTrue(getByIdResponse.StatusCode == System.Net.HttpStatusCode.OK,"Pass");
                count++;
            }

            //Update Test
            content = new StringContent(JsonConvert.SerializeObject(new Item() { Id = 5, Name = "Hair Oil",Price = 0,Discription="",ImageUrl = "" }), Encoding.UTF8, "application/json");
            HttpResponseMessage updateResponse = client.PutAsync($"/api/item",content).Result;
            Assert.IsNotNull(updateResponse);
            Assert.IsTrue(updateResponse.StatusCode == System.Net.HttpStatusCode.OK);

            //Delete Test
            HttpResponseMessage deleteResponse = client.DeleteAsync($"/api/item/{items[0].Id}").Result;
            Assert.IsNotNull(deleteResponse);
            Assert.IsTrue(deleteResponse.StatusCode == System.Net.HttpStatusCode.OK);

            
        }

    }
}

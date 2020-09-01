using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GUI.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/OrderFromStock")]
    
    public class OrderFromStockController : ApiController
    {
        // GET: api/OrderFromStock
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OrderFromStock/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OrderFromStock
        public void Post([FromBody]string value)
        {
        }

        [Route("AddOrderToStock/{id_shoe}/{id_branch}/{size}/{color}/{name}")]
        [HttpPost]
        public int AddOrderToStock([FromUri] int id_shoe, int id_branch, int size, string color, string name,[FromBody] int tryy)
        {
          return  BL.OrdersFromStockBL.AddOrderToStock(id_shoe, id_branch, size,color,name);
        }

        [Route("GetOrderFromStock/{id_branch}")]
        [HttpGet]
        public OrderDetails GetOrderFromStock(int id_branch)
        {
          return  BL.OrdersFromStockBL.GetOrderFromStock(id_branch);
             

        }
        [Route("GetNumInQueue/{id_branch}")]
        [HttpGet]
        public int GetNumInQueue(int id_branch)
        {
            return BL.OrdersFromStockBL.GetNumInQueue(id_branch);
        }
        // PUT: api/OrderFromStock/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OrderFromStock/5
        public void Delete(int id)
        {
        }
    }
}

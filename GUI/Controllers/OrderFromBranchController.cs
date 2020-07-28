using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;

namespace GUI.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/OrderFromBranch")]
    public class OrderFromBranchController : ApiController
    {
        // GET: api/OrderFromBranch
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("GetOrderfromBranch/{id}")]
        [HttpGet]
        public OrderDetails GetOrderfromBranch([FromUri] int id)
        {
            return BL.OrderFromBranchBL.GetOrderfromBranch(id);
        }
        // GET: api/OrderFromBranch/5
        public string Get(int id)
        {
            return "value";
        }


        // POST: api/OrderFromBranch
        [Route("AddOrderToBranch")]
        [HttpPost]
        public bool AddOrderToBranch([FromBody] BL.OrderDetails order)
        {
            return BL.OrderFromBranchBL.AddOrderFromBranch(order);

        }

        // PUT: api/OrderFromBranch/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OrderFromBranch/5
        public void Delete(int id)
        {
        }
    }
}

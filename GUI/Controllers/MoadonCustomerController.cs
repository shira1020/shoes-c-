using BL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GUI.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/MoadonCustomer")]
    public class MoadonCustomerController : ApiController
    {
        // GET: api/MoadonCustomer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MoadonCustomer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MoadonCustomer
        public void Post([FromBody]string value)
        {
        }

        [Route("AddMoadonCustomer")]
        [HttpPost]
        public bool AddMoadonCustomer([FromBody] MoadonCustomerDTO cust)
        {
            return BL.MoadonCustomerBL.AddMoadonCustomer(cust);
        }

        // PUT: api/MoadonCustomer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MoadonCustomer/5
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;

namespace GUI.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Stock")]
    public class StockController : ApiController
    {
        // GET: api/Stock
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Stock/5
        public string Get(int id)
        {
            return "value";
        }


        [Route("GetBranchesByShoe/{id_shoe}/{size}/{color}")]
        [HttpGet]
        public branchDetails[] GetBranchesByShoe([FromUri] int id_shoe, int size, string color)
        {
            return BL.StockBL.GetBranchesByShoe(id_shoe, size, color);
        }


        [Route("IsFoundInStock/{id_shoe}/{id_branch}/{size}/{color}")]
        [HttpGet]
        public bool IsFoundInStock([FromUri] int id_shoe, int id_branch, int size,  string color)
        {
            bool a= BL.StockBL.IsFoundInStock(id_shoe, id_branch, size ,color);
            return a;
        }
		
		// POST: api/Stock
		public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stock/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stock/5
        public void Delete(int id)
        {
        }
    }
}

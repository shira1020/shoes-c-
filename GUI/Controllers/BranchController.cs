using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GUI.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Branch")]
    public class BranchController : ApiController
    {
        // GET: api/Branch
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Branch/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("GetAllBranches")]
        [HttpGet]
        public string[] GetAllBranches()
        {
            return BL.BranchBL.GetAllBranches();
        }


        [Route("GetIdBranchByName/{name}")]
        [HttpGet]
        public int GetIdBranchByName([FromUri] string name)
        {
            return BL.BranchBL.GetIdBranchByName(name);
        }

        [Route("GetBranchNameById/{id}")]
        [HttpGet]
        public string GetBranchNameById([FromUri] int id)
        {
            return BL.BranchBL.GetBranchNameById(id);
        }


        //[Route("MyBranch/{password}")]
        //[HttpGet]
        //public int MyBranch([FromUri] string password)
        //{
        //    return BL.EmployeeBL.MyBranch(password);
        //}

        // POST: api/Branch
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Branch/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Branch/5
        public void Delete(int id)
        {
        }
    }
}

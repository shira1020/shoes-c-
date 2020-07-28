using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GUI.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Employee/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("IsEmployee/{id_emp}/{pass}")]
        [HttpGet]
        public int IsEmployee( [FromUri] string id_emp, string pass)
        {
            return BL.EmployeeBL.IsEmployee(id_emp, pass);
        }


        //[Route("IsWorker/{password}")]
        //[HttpGet]
        //public bool IsWorker([FromUri] string password)
        //{
        //    return BL.EmployeeBL.IsWorker(password);
        //}
        // POST: api/Employee
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}

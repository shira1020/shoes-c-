using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using DAL;
using DTO;

namespace GUI.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins:"*",headers:"*",methods:"*")]
    [RoutePrefix("api/Shoes")]
    public class ShoesController : ApiController
    {
        // GET: api/Shoes
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("GetImageById/{id}")]
        [HttpGet]
        // GET: api/Shoes/5
        public string GetImageById([FromUri] int id)
        {
            return BL.ShoesBL.GetImageById(id);
        }
		[Route("GetColors")]
		[HttpGet]
		public List<BL.ColorBL> GetColors()
		{
			return BL.ShoesBL.GetColors();
		}
		[Route("GetDetailsById/{id}")]
        [HttpGet]
        // GET: api/Shoes/5
        public shoeDetails GetDetailsById([FromUri] int id)
        {
            return BL.ShoesBL.GetDetailsById(id);
        }
		[Route("AddMoadonCustomer")]
		[HttpPost]
		public bool AddMoadonCustomer([FromBody] MoadonCustomerDTO cust)
		{
			return BL.MoadonCustomerBL.AddMoadonCustomer(cust);
		}
		[Route("OnUpload")]
		[HttpPost]
		public int onUpload( [FromBody]addShoe shoe)
		{
			return BL.ShoesBL.OnUpload(shoe);
		}

		[Route("GetColorsById/{id}")]
        [HttpGet]
        public string[] GetColorsById([FromUri] int id)
        { 
            string[] arry =BL.ShoesBL.GetColorsById(id).ToArray();
            return arry;
        }

        [Route("GetSizesById/{id}")]
        [HttpGet]
        public int[] GetSizesById([FromUri] int id)
        {
            return BL.ShoesBL.GetSizesById(id);
        }
        // POST: api/Shoes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Shoes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Shoes/5
        public void Delete(int id)
        {
        }
    }
}

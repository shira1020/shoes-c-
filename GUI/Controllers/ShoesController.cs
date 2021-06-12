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
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Shoes")]
    public class ShoesController : ApiController
    {
        // GET: api/Shoes
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("GetShoesByCategory/{size}/{color}/{kind}/{type}/{price}")]
        [HttpGet]
        public ShoeDTO[] GetShoesByCategory([FromUri] int size, int color, int kind, string type, int price)
        {
            return BL.ShoesBL.GetShoesByCategory(size, color, kind, type, price);
        }

        [Route("GetImageById/{id}")]
        [HttpGet]
        // GET: api/Shoes/5
        public string GetImageById([FromUri] int id)
        {
            return BL.ShoesBL.GetImageById(id);
        }
        [Route("GetSizes")]
        [HttpGet]
        public int[] GetSizes()
        {
            return BL.ShoesBL.GetSizes();
        }
        [Route("GetTypes")]
        [HttpGet]
        public List<string> GetTypes()
        {
            return BL.ShoesBL.GetTypes();
        }
		[Route("GetColors")]
        [HttpGet]
        public List<ColorBL> GetColors()
        {
           return BL.ColorBL.GetColors();
            
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
        public int onUpload([FromBody]addShoe shoe)
        {
            return BL.ShoesBL.AddShoe(shoe);
        }

        [Route("GetColorsById/{id}")]
        [HttpGet]
        public string[] GetColorsById([FromUri] int id)
        {
            string[] arry = BL.ColorBL.GetColorsById(id).ToArray();
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

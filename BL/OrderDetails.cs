using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class OrderDetails
    {
        public string name_customer { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int to_branch { get; set; }
        public int id_shoe { get; set; }
        public int size { get; set; }
        public string color { get; set; }
        public string picture { get; set; }
        public int order_id { get; set; }
        public string order_date { get; set; }

    }
}

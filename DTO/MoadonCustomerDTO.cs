using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MoadonCustomerDTO
    {
        public int id_customer { get; set; }
        public string f_name { get; set; }
        public string l_name { get; set; }
        public Nullable<System.DateTime> born_date { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Nullable<int> bonus_points { get; set; }
        public string password { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public Nullable<int> house_number { get; set; }
    }
}

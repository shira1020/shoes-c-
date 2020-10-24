using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ShoeDTO
    {
        public int id_shoe { get; set; }
        public Nullable<int> model { get; set; }
        public string picture { get; set; }
        public Nullable<int> kind { get; set; }
        public Nullable<int> price { get; set; }
        public Nullable<int> from_size { get; set; }
        public Nullable<int> to_size { get; set; }
    }
}

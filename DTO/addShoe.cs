using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class addShoe
    {
        public  ShoeDTO   shoe{ get; set; }
        public  int[]   colors{ get; set; }
       
     
        public addShoe()
        {
        }

        public addShoe(ShoeDTO shoe, int[] colors)
        {
            this.shoe = shoe;
            this.colors = colors;
        }
    }
}

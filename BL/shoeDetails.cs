using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class shoeDetails
    {
        public string img { get; set; }
        public string[] colors { get; set; }
        public int[] sizes { get; set; }
        public int price { get; set; }

        public shoeDetails()
        {

        }

        public shoeDetails(string img, string[] colors, int[] sizes, int price)
        {
            this.img = img;
            this.colors = colors;
            this.sizes = sizes;
            this.price = price;
        }
    }
}

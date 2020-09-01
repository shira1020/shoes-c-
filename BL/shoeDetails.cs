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
        public double salePrice { get; set; }
        public string saleName { get; set; }
        public shoeDetails()
        {

        }

        public shoeDetails(string img, string[] colors, int[] sizes, int price, double salePrice, string saleName)
        {
            this.img = img;
            this.colors = colors;
            this.sizes = sizes;
            this.price = price;
            this.salePrice = salePrice;
            this.saleName = saleName;
        }
    }
}

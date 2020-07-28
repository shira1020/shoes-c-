using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL
{
    public class ShoesBL
    {

        public static string GetImageById(int id)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
               string img=db.Shoes.First(s => s.id_shoe == id).picture;
                return img;
               
            }
        }

        public static List<string> GetColorsById(int id)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                Sho s = db.Shoes.First(sh => sh.id_shoe == id);
                return s.Colors.Select(sh => sh.color1).ToList();
            }
        }

        public static int[] GetSizesById(int id)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
               Sho s = db.Shoes.First(sh => sh.id_shoe == id);
                int from_size = s.from_size.Value;
                int to_size = s.to_size.Value;
                int[] sizes = new int[to_size - from_size+1];
                for (int i = 0; i < sizes.Length; i++)
                {
                    sizes[i] = from_size++;
                }
                return sizes;
            }
        }


        public static shoeDetails GetDetailsById(int id)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                Sho s = db.Shoes.First(sh => sh.id_shoe == id);
                shoeDetails shoe = new shoeDetails();
                //set img
                shoe.img = s.picture;
                //set sizes
                int from_size = s.from_size.Value;
                int to_size = s.to_size.Value;
                int[] sizes = new int[to_size - from_size + 1];
                for (int i = 0; i < sizes.Length; i++)
                {
                    sizes[i] = from_size++;
                }
                shoe.sizes = sizes;
                //set coloers
                shoe.colors= s.Colors.Select(sh => sh.color1).ToList().ToArray();
                //set price
                shoe.price =Int32.Parse(s.price.ToString());
                return shoe;
 
            }
        }
    }
}

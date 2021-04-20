using DAL;
using DTO;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BL
{
    public class ShoesBL
    {
        //get shoe image name by id's shoe
        public static string GetImageById(int id)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                string img = db.Shoes.First(s => s.id_shoe == id).picture;
                return img;

            }
        }

        //add shoe to the database
        public static int AddShoe(addShoe sh)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                try
                {


                    Sho s = converters.ShoeConverter.ShoeToDAL(sh.shoe);

                    int x;
                    for (int i = 0; i < sh.colors.Length; i++)
                    {
                        x = sh.colors[i];
                        Color c = db.Colors.Where(c1 => c1.id_color == x).First();
                        s.Colors.Add(c);
                    }
                    db.Shoes.Add(s);
                    db.SaveChanges();

                    int id = db.Shoes.Select(s1 => s1.id_shoe).Max();

                    return id;
                }
                catch (Exception e)
                { return 0; }
            }
        }

        public static int[] GetSizes()
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                Sho sh = new Sho();
                int fromsize = 34;
                int tosize = 42;
                int[] size = new int[tosize - fromsize + 1];
                for (int i = 0; i < size.Length; i++)
                {
                    size[i] = fromsize++;
                }
                return size;
            }
        }

        public static List<string> GetTypes()
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                List<string> types = new List<string>();
                types = db.ShoeDescriptions.Select(s => s.name_description).ToList();
                return types;
            }
        }
            //get sizes of specific shoe by id
            public static int[] GetSizesById(int id)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                Sho s = db.Shoes.First(sh => sh.id_shoe == id);
                int from_size = s.from_size.Value;
                int to_size = s.to_size.Value;
                int[] sizes = new int[to_size - from_size + 1];
                for (int i = 0; i < sizes.Length; i++)
                {
                    sizes[i] = from_size++;
                }
                return sizes;
            }
        }

        //get al the details of specific shoe by id
        public static shoeDetails GetDetailsById(int id)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                try
                {

                    int idBranch = 1;
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
                    shoe.colors = s.Colors.Select(sh => sh.color1).ToList().ToArray();
                    //set price
                    shoe.price = Int32.Parse(s.price.ToString());
                    //find sale
                    try
                    {
                        List<Sale> l = db.Stocks.First(s1 => s1.id_shoe == id && s1.id_branch == idBranch).Sales.ToList();
                        Sale minSale = l.OrderBy(s2 => s2.precent_sale).First(s3 => s3.start_date <= DateTime.Now && s3.end_date >= DateTime.Now);
                        shoe.salePrice = (double)(shoe.price * (1 - minSale.precent_sale));
                        shoe.saleName = minSale.description_sale;
                    }
                    catch (Exception e)
                    {
                        shoe.salePrice = shoe.price;
                        shoe.saleName = "no sale now";
                    }

                    return shoe;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        //get shoes that meets constraints by the parameters
        public static ShoeDTO[] GetShoesByCategory(int size, string color, int kind, string desc)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                List<Sho> list = new List<Sho>();
                List<Sho> FinalList = new List<Sho>();

                list = db.Shoes.Where(s => s.from_size <= size && s.to_size >= size
                && s.kind == kind).ToList();
                foreach (var shoe in list)
                {
                    if (shoe.Colors.Any(s => s.color1 == color) &&
                        shoe.ShoeDescriptions.Any(s => s.name_description == desc))
                        FinalList.Add(shoe);
                }
                return converters.ShoeConverter.ShoeListToDTO(FinalList).ToArray();
            }
        }
    }
}

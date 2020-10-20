﻿using DAL;
using DTO;
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
                string img = db.Shoes.First(s => s.id_shoe == id).picture;
                return img;

            }
        }
		public static bool OnUpload(ShoeDTO shoe)
		{
			using (DB_shoesEntities5 db = new DB_shoesEntities5())
			{
				try
				{
					db.Shoes.Add(converters.ShoeConverter.ShoeToDAL(shoe));

					db.SaveChanges();
					return true;
				}
				catch (Exception e)
				{ return false; }
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
                int[] sizes = new int[to_size - from_size + 1];
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
   List<Sale> l= db.Stocks.First(s1 => s1.id_shoe == id && s1.id_branch == idBranch).Sales.ToList();
                Sale minSale = l.OrderBy(s2 => s2.precent_sale).First(s3=>s3.start_date<=DateTime.Now&&s3.end_date>=DateTime.Now);
                shoe.salePrice =(double)(shoe.price*(1-minSale.precent_sale));
                shoe.saleName = minSale.description_sale;
                }
             catch(Exception e)
                {
                    shoe.salePrice = shoe.price;
                    shoe.saleName = "no sale now";
                }
               


                return shoe;

            }
        }

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

using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class ColorBL
	{
		public int id_color { get; set; }
		public string color { get; set; }

        public static List<ColorBL> GetColors()
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                List<ColorBL> colors = new List<ColorBL>();
                return db.Colors.ToList().Select(c =>
                {
                    ColorBL color = new ColorBL();
                    color.color = c.color1;
                    color.id_color = c.id_color;
                    return color;
                }).ToList();
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
    }
}

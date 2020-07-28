using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class StockBL
    {
        public static bool IsFoundInStock(int id_shoe, int id_branch, int size, string color)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                bool b = db.Stocks.Any(s => s.id_branch == id_branch && s.id_shoe == id_shoe
                 && s.size == size && s.color == color && s.available_amount > 0);
                return b;
            }
        }

        //public static string[][] GetBranchesByShoe(int id_shoe, int size, string color)
        //{
        //    using (DB_shoesEntities5 db = new DB_shoesEntities5())
        //    {
        //        List<string>[] mat;
        //        mat = new List<string>[2];
        //        for (int i = 0; i < mat.Length; i++)
        //        {
        //            mat[i] = new List<string>();
        //        }
        //        IEnumerable<int> list = db.Stocks.Where(s => s.id_shoe == id_shoe
        //        && s.size == size && s.color == color && s.available_amount > 0).Select(s => s.id_branch);
        //        //List<string> l=new List<string>();
        //        //List<string> l2 = new List<string>();

        //        //list.ToList().ForEach(b => l.Add(
        //        //db.Branches.First(s => s.id_branch == b).city)) ;

        //        //new { name = d.name_branch,}+ ' ' + d.street + ' ' + d.house_number 
        //        int index = 0; Branch b;
        //        foreach (var item in list)
        //        {
        //            b = db.Branches.First(s => s.id_branch == item);
        //            mat[index][0] = b.name_branch;
        //            mat[index][1] = b.street + ' ' + b.house_number + ',' + b.city;
        //            index++;
        //        }
        //        return mat;
        //    }

        //   }
        public static List<string>[] GetBranchesByShoe2(int id_shoe, int size, string color)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                
                List<string>[] mat;
                mat = new List<string>[2];
                for (int i = 0; i < mat.Length; i++)
                {
                    mat[i] = new List<string>();
                }


                var list = db.Stocks.Where(s => s.id_shoe == id_shoe
                 && s.size == size && s.color == color && s.available_amount > 0).Select(s => s.id_branch);
                Branch b;
                foreach (var item in list)
                {
                    b = db.Branches.First(s => s.id_branch == item);
                    mat[0].Add(b.name_branch);
                    mat[1].Add(b.street + ' ' + b.house_number + ',' + b.city);
                }
                return mat;

            }




        }

    }
}

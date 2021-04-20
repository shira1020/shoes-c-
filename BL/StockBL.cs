using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class StockBL
    {
        //check if shoe exist in stock that meets constraints by the parameters
        public static bool IsFoundInStock(int id_shoe, int id_branch, int size, string color)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                return db.Stocks.Any(s => s.id_branch == id_branch && s.id_shoe == id_shoe
                 && s.size == size && s.color == color && s.available_amount > 0);

            }
        }



        //public static List<string>[] GetBranchesByShoe2(int id_shoe, int size, string color)
        //      {
        //          using (DB_shoesEntities5 db = new DB_shoesEntities5())
        //          {

        //              List<string>[] mat;
        //              mat = new List<string>[2];
        //              for (int i = 0; i < mat.Length; i++)
        //              {
        //                  mat[i] = new List<string>();
        //              }

        //              var list = db.Stocks.Where(s => s.id_shoe == id_shoe
        //               && s.size == size && s.color == color && s.available_amount > 0).Select(s => s.id_branch);
        //              Branch b;
        //              foreach (var item in list)
        //              {
        //                  b = db.Branches.First(s => s.id_branch == item);
        //                  mat[0].Add(b.name_branch);
        //                  mat[1].Add(b.street + ' ' + b.house_number + ',' + b.city);
        //              }
        //              return mat;

        //          }
    }
}





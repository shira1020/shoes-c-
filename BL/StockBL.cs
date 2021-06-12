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

        public static branchDetails[] GetBranchesByShoe(int id_shoe, int size, string color)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                List<Stock> stock_list = new List<Stock>();
                List<Branch> branch_list = new List<Branch>();
                List<Stock> stock = new List<Stock>();

                stock = db.Stocks.Where(s => s.id_shoe == id_shoe).ToList();

                stock_list = db.Stocks.Where(s => s.id_shoe == id_shoe && s.size == size
                && s.color == color).ToList();
                stock_list = stock_list.Distinct().ToList();

                foreach (var stock_item in stock_list)
                {
                    branch_list.Add(
                         db.Branches.First(b => b.id_branch == stock_item.id_branch));
                }
                return converters.branchConverter.BranchListToDTO(branch_list).ToArray();
            }
        }


    }
}





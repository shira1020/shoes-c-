using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class BranchBL
    {
        //function to get all the branches's name
        public static string[] GetAllBranches()
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
              int cnt=  db.Branches.Count();
              string[] branches = new string[cnt];
              branches = db.Branches.Select(s => s.name_branch).ToArray();
              return branches;
            }
        }
       
        //function to get a branches's id by name
        public static int GetIdBranchByName(string name)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                return db.Branches.First(b=>b.name_branch==name).id_branch;
            }
        }
   
        public static string GetBranchNameById(int id)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                string x=    db.Branches.First(b => b.id_branch == id).name_branch;
                return x;
            }
        }
        public static List<branchDetails> GetBranchByShoe(int idshoe, int size, string color)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                var list = db.Stocks.Where(s => s.id_shoe == idshoe
                && s.size == size && s.color == color && s.available_amount > 0).Select(s => s.id_branch).ToList();
                List<Branch> branches = new List<Branch>();
                foreach (var item in list)
                {
                    Branch b = db.Branches.First(a => a.id_branch == item);
                    branches.Add(b);

                }
                return branches.Select(b =>converters.branchConverter.ConvertToBranchDTO(b)).ToList();
            }

        }
    }
}

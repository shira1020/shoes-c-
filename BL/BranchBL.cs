using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class BranchBL
    {

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

        public static int GetIdBranchByName(string name)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                return db.Branches.First(b=>b.name_branch==name).id_branch;
            }
        }

    }
}

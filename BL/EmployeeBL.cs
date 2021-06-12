using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class EmployeeBL
    {
        public static int IsEmployee(string id_emp,string pass)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                if (db.Employees.Any(e => e.password == pass && e.id_employee == id_emp))
                {
                    if (db.Employees.First(e => e.password == pass && e.id_employee == id_emp).is_manager == true)
                    {
                        int id = db.Employees.First(e => e.password == pass).employee_num;
                        return db.Branches.First(b => b.manager_id == id).id_branch;
                    }
                    else
                        return 0;
               
                }
                return -1;
            }
        }

        //public static int MyBranch(string pass)
        //{
        //    using (DB_shoesEntities5 db = new DB_shoesEntities5())
        //    {
        //       int id= db.Employees.First(e => e.password == pass).employee_num;
        //       return db.Branches.First(b => b.manager_id == id).id_branch;
        //    }
        //}

        //public static bool IsWorker(string pass)
        //{
        //    using (DB_shoesEntities5 db = new DB_shoesEntities5())
        //    {
        //        if (db.Employees.Any(e => e.password == pass))
        //        {
        //            if (db.Employees.First(e => e.password == pass).is_manager == false)
        //                return true;
        //        }
        //        return false;
        //    }
        //}
    }
}

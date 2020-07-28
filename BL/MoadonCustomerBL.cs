using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MoadonCustomerBL
    {

        public static bool AddMoadonCustomer(MoadonCustomerDTO customer)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                try
                {

                    db.MoadonCustomers.Add(
                        converters.MoadonCustomerConverter.ConvertMoadonCustomerToDAL(customer)
                     );


                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }

        }
    }
}

using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.converters
{
   public class MoadonCustomerConverter
    {
        public static MoadonCustomer ConvertMoadonCustomerToDAL(MoadonCustomerDTO customer)
        {
            return new MoadonCustomer
            {
                id_customer = customer.id_customer,
                f_name = customer.f_name,
                l_name = customer.l_name,
                born_date = customer.born_date,
                phone = customer.phone,
                email = customer.email,
                bonus_points = customer.bonus_points,
                city = customer.city,
                street = customer.street,
                house_number = customer.house_number,
                password = customer.password
            };
        }

    }
}

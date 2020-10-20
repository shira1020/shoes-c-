using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

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
                 //   sendSms();
                  //  SendMail(customer.email);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }

        }
        public static void SendMail(string email)
        {
            var fromAddress = new MailAddress("shoestime20@gmail.com", "Shoes-Time");
            var toAddress = new MailAddress("1020shira@gmail.com", "To Name");
            const string fromPassword = "s123s456";
            const string subject = "Welcome to Shoes Time";
            const string body = "hi Shira, its work!!!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}

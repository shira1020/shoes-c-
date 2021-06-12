using DAL;
using DTO;
using System;
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

                    MoadonCustomer m = converters.MoadonCustomerConverter.ConvertMoadonCustomerToDAL(customer);
                    // db.MoadonCustomers.Add(m);
                    // db.SaveChanges();



                    var fromAddress = new MailAddress("shoestime20@gmail.com" , "Shoes-Time");
                    var toAddress = new MailAddress(customer.email, "To Name");
                    const string fromPassword = "s123s456";
                    const string subject = "Welcome to Shoes Time";
                    string body = $" Hi { customer.f_name} { customer.l_name} You have successfully joined our club card. \n " +
                        $"We hope meet you again soon \n Thanks ";
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
     
                   smtp.Send(message);

                       
                    
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

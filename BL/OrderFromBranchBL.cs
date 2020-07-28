using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrderFromBranchBL
    {
        public static int AddCustomerToOrder(string mail, string phone, string name)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                CustomersToOrder cust = new CustomersToOrder();
                cust.email = mail;
                cust.phone = phone;
                cust.name_customer = name;
                db.CustomersToOrders.Add(cust);
                db.SaveChanges();
                int x = cust.id_customer;
                return x;
            }
        }

        public static bool AddOrderFromBranch(OrderDetails order)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                try
                {
                    int id_cust = AddCustomerToOrder(order.email, order.phone, order.name_customer);
                    int from_b = db.Stocks.First(s => s.id_shoe == order.id_shoe
                    && s.size == order.size && s.color == order.color).id_branch;

                    db.OrdersFromBranches.Add(
                        new OrdersFromBranch
                        {
                            id_shoe = order.id_shoe,
                            to_branch = order.to_branch,
                            from_branch = from_b,
                            id_cust = id_cust,
                            size = order.size,
                            color = order.color,
                            order_date = DateTime.Today,
                            status = false
                        }
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


        public static OrderDetails GetOrderfromBranch(int id_branch)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                try
                {
                    OrderDetails order = new OrderDetails();
                    OrdersFromBranch order_from = db.OrdersFromBranches.First(o => o.from_branch == id_branch && o.status == false);
                    CustomersToOrder cust = db.CustomersToOrders.First(c => c.id_customer == order_from.id_cust);
                    order.id_shoe = order_from.id_shoe;
                    order.color = order_from.color;
                    order.size = (Int32)order_from.size;
                    order.name_customer = cust.name_customer;
                    order.picture = db.Shoes.First(s => s.id_shoe == order_from.id_shoe).picture;
                    order_from.status = true;
                    order.phone = cust.phone;
                    order.email = cust.email;
                    order.order_id = order_from.id_order;
                    order.order_date = order_from.order_date.ToString();
                    db.SaveChanges();
                    return order;
                }
                catch (Exception e)
                {
                    return null;
                }

            }

        }
    }
}
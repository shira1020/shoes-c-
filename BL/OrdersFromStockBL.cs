using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrdersFromStockBL
    {
        public static int AddOrderToStock(int id_shoe, int id_branch, int size, string color, string name)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                db.OrdersFromStocks.Add(
                    new OrdersFromStock
                    {
                        id_shoe = id_shoe,
                        id_branch = id_branch,
                        size = size,
                        color = color,
                        customer_name = name,
                        status = 0
                    }
                    );
                Stock stock = db.Stocks.First(s => s.id_branch == id_branch && s.id_shoe == id_shoe
                 && s.size == size && s.color == color);
                stock.available_amount--;
                try
                {
                    db.SaveChanges();
                    return stock.id_stock;
                }
                catch (Exception e)
                {
                    return 0;
                }

            }
        }

        public static OrderDetails GetOrderFromStock(int id_branch)
        {

            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                try
                {
                    OrderDetails order = new OrderDetails();
                    OrdersFromStock order_from = db.OrdersFromStocks.First(o => o.id_branch == id_branch && o.status == 0);
                    order.id_shoe = order_from.id_shoe;
                    order.color = order_from.color;
                    order.size = (Int32)order_from.size;
                    order.name_customer = order_from.customer_name;
                    order.picture = db.Shoes.First(s => s.id_shoe == order_from.id_shoe).picture;
                    order_from.status = 1;
                    db.SaveChanges();
                    return order;
                }
                catch (Exception e)
                {
                    return null;
                }

            }
        }
        public static int GetNumInQueue(int id_branch)
        {
            using (DB_shoesEntities5 db = new DB_shoesEntities5())
            {
                return db.OrdersFromStocks.Count(o => o.id_branch == id_branch && o.status == 0);
            }
        }
    }
}

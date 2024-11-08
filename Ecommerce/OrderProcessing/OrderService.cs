using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public class OrderService : IOrderService
    {
        private List<Order> orders;
        public OrderService() {
            this.orders = new List<Order>();
        }
        public bool Delete(int id)
        {
            Order order = this.GetOrder(id);
            orders.Remove(order);
            return true;
        }

        public Order GetOrder(int id)
        {
            foreach(Order o in orders)
            {
                if (o.Id == id)
                {
                    return o;
                }
            }
            return null;
        }

        public List<Order> GetOrders()
        {
            return orders;
        }

        public bool Insert(Order order)
        {
            orders.Add(order);
            return true;
        }

        public bool Update(Order order)
        {
            Order order1 = this.GetOrder(order.Id);
            orders.Remove(order1);
            orders.Add(order);
            return true;
        }
    }
}

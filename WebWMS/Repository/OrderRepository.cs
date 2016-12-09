using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebWMS.Models;

namespace WebWMS.Repository
{
    public class OrderRepository : IOrderRepository
    {
        static List<OrderModel> OrderList = new List<OrderModel>();

        public void Add(OrderModel order)
        {
            OrderList.Add(order);
        }

        public OrderModel Find(int id)
        {
            return OrderList
                .Where(o => o.OrderId.Equals(id))
                .SingleOrDefault();
        }

        public IEnumerable<OrderModel> GetAll()
        {
            return OrderList;
        }

        public void Remove(int Id)
        {
            var order = OrderList.SingleOrDefault(r => r.OrderId == Id);
            if (order != null)
                OrderList.Remove(order);
        }

        public void Update(OrderModel order)
        {
            var orderUpdate = OrderList.SingleOrDefault(r => r.OrderId == order.OrderId);
            if (orderUpdate != null)
            {
                orderUpdate.OrderId = order.OrderId;
                orderUpdate.OrderState = order.OrderState;
                orderUpdate.Description = order.Description;
                orderUpdate.StateChangeTime = order.StateChangeTime;
            }
        }
    }
}
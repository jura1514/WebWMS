using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWMS.Models;

namespace WebWMS.Repository
{
    public interface IOrderRepository
    {
        void Add(OrderModel order);
        OrderModel Find(int id);
        IEnumerable<OrderModel> GetAll();
        void Remove(int id);
        void Update(OrderModel order);
    }
}
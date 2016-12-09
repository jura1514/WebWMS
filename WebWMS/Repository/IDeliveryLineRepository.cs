using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWMS.Models;

namespace WebWMS.Repository
{
    public interface IDeliveryLineRepository
    {
        void Add(DeliveryLineModel delLine);
        DeliveryLineModel Find(int id);
        IEnumerable<DeliveryLineModel> GetAll();
        void Remove(int id);
        void Update(DeliveryLineModel delLine);
    }
}

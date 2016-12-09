using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWMS.Models;

namespace WebWMS.Repository
{
    public interface IDeliveryRepository
    {
        void Add(DeliveryModel del);
        DeliveryModel Find(int id);
        IEnumerable<DeliveryModel> GetAll();
        void Remove(int id);
        void Update(DeliveryModel del);
    }
}
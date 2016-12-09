using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebWMS.Models;

namespace WebWMS.Repository
{
    public class DeliveryRepository : IDeliveryRepository
    {
        static List<DeliveryModel> DeliveriesList = new List<DeliveryModel>();

        public void Add(DeliveryModel del)
        {
            DeliveriesList.Add(del);
        }

        public DeliveryModel Find(int id)
        {
            return DeliveriesList
                .Where(o => o.DeliveryId.Equals(id))
                .SingleOrDefault();
        }

        public IEnumerable<DeliveryModel> GetAll()
        {
            return DeliveriesList;
        }

        public void Remove(int Id)
        {
            var del = DeliveriesList.SingleOrDefault(r => r.DeliveryId == Id);
            if (del != null)
                DeliveriesList.Remove(del);
        }

        public void Update(DeliveryModel del)
        {
            var delUpdate = DeliveriesList.SingleOrDefault(r => r.DeliveryId == del.DeliveryId);
            if (delUpdate != null)
            {
                delUpdate.DeliveryId = del.DeliveryId;
                delUpdate.Name = del.Name;
                delUpdate.ExpectedDate = del.ExpectedDate;
                delUpdate.Customer = del.Customer;
                delUpdate.State = del.State;
                delUpdate.StateChangeTime = del.StateChangeTime;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebWMS.Models;

namespace WebWMS.Repository
{
    public class DeliveryLineRepository : IDeliveryLineRepository
    {
        static List<DeliveryLineModel> DelLinesList = new List<DeliveryLineModel>();

        public void Add(DeliveryLineModel delLine)
        {
            DelLinesList.Add(delLine);
        }

        public DeliveryLineModel Find(int id)
        {
            return DelLinesList
                .Where(o => o.DeliveryLineId.Equals(id))
                .SingleOrDefault();
        }

        public IEnumerable<DeliveryLineModel> GetAll()
        {
            return DelLinesList;
        }

        public void Remove(int Id)
        {
            var delLine = DelLinesList.SingleOrDefault(r => r.DeliveryLineId == Id);
            if (delLine != null)
                DelLinesList.Remove(delLine);
        }

        public void Update(DeliveryLineModel delLine)
        {
            var delLineUpdate = DelLinesList.SingleOrDefault(r => r.DeliveryLineId == delLine.DeliveryLineId);
            if (delLineUpdate != null)
            {
                delLineUpdate.DeliveryLineId = delLine.DeliveryLineId;
                delLineUpdate.DeliveryId = delLine.DeliveryId;
                delLineUpdate.Name = delLine.Name;
                delLineUpdate.AcceptedQty = delLine.AcceptedQty;
                delLineUpdate.ExpectedQty = delLine.ExpectedQty;
                delLineUpdate.Product = delLine.Product;
                delLineUpdate.RejectedQty = delLine.RejectedQty;
            }
        }
    }
}
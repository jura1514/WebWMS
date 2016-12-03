using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebWMS.Models;

namespace WebWMS.Data
{
    public class WmsInitializer
    {
        public static void Initialize()
        {
            WMSContext context = new WMSContext();

            var _deliveries = new DeliveryModel[]
            {
                new DeliveryModel { DeliveryId = 1, Name = "Rest Test Del 1", State = "Testing", Customer = "Test", ExpectedDate = DateTime.Now, StateChangeTime = DateTime.Now },
                new DeliveryModel { DeliveryId = 2, Name = "Rest Test Del 2", State = "Testing", Customer = "Test", ExpectedDate = DateTime.Now, StateChangeTime = DateTime.Now },
            };

            foreach (DeliveryModel d in _deliveries)
            {
                context.DeliveryModels.Add(d);
            }
            context.SaveChanges();

            var _delLines = new DeliveryLineModel[]
            {
                new DeliveryLineModel { DeliveryLineId = 1, Name = "Rest test 1", DeliveryId = _deliveries.Single( s => s.Name == "Rest Test Del 1").DeliveryId, Product = "Oil And Gas", AcceptedQty = 0, ExpectedQty = 5, RejectedQty = 0 },
                new DeliveryLineModel { DeliveryLineId = 2, Name = "Rest test 2",DeliveryId = _deliveries.Single( s => s.Name == "Rest Test Del 1").DeliveryId, Product = "Oil And Gas", AcceptedQty = 0, ExpectedQty = 5, RejectedQty = 0 },
            };

            foreach (DeliveryLineModel dl in _delLines)
            {
                context.DeliveryLineModels.Add(dl);
            }
            context.SaveChanges();

        }
    }
}
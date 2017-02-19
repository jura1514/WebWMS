using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebWMS.Models
{
    public partial class DeliveryLineModel
    {
        public DeliveryLineModel()
        {
            Picks = new HashSet<PickModel>();
            StockList = new HashSet<StockModel>();
        }

        [Key]
        public int DeliveryLineId { get; set; }

        public string Name { get; set; }

        public int DeliveryId { get; set; }

        public string Product { get; set; }

        public int ExpectedQty { get; set; }

        public int AcceptedQty { get; set; }

        public int RejectedQty { get; set; }

        public bool isUsedForStock { get; set; }

        [JsonIgnore]
        [ForeignKey("DeliveryId")]
        public virtual DeliveryModel DeliveryModel { get; set; }

        [JsonIgnore]
        [ForeignKey("Product")]
        public virtual ProductModel ProductModel { get; set; }

        [JsonIgnore]
        public virtual ICollection<PickModel> Picks { get; set; }

        [JsonIgnore]
        public virtual ICollection<StockModel> StockList { get; set; }

    }
}
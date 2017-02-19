using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebWMS.Models
{
    public partial class PickModel
    {
        [Key]
        public int PickId { get; set; }

        public int OrderId { get; set; }

        public int DeliveryLineId { get; set; }

        public string Product { get; set; }

        public string PickState { get; set; }

        public DateTime StateChangeTime { get; set; }

        public string Description { get; set; }

        public int ActualQty { get; set; }

        public int PlannedQty { get; set; }

        [JsonIgnore]
        [ForeignKey("OrderId")]
        public virtual OrderModel OrderModel { get; set; }

        [JsonIgnore]
        [ForeignKey("DeliveryLineId")]
        public virtual DeliveryLineModel DeliveryLineModel { get; set; }

        [JsonIgnore]
        [ForeignKey("Product")]
        public virtual ProductModel ProductModel { get; set; }
    }
}
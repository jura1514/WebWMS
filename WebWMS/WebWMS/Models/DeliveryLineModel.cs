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

    }
}
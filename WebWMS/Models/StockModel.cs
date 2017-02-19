using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebWMS.Models
{
    public class StockModel
    {
        [Key]
        public int StockId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DeliveryLineId { get; set; }

        public string Product { get; set; }

        public string Location { get; set; }

        public string StockState { get; set; }

        public DateTime StateChangeTime { get; set; }

        public int Qty { get; set; }

        [JsonIgnore]
        [ForeignKey("DeliveryLineId")]
        public virtual DeliveryLineModel DeliveryLineModel { get; set; }

        [JsonIgnore]
        [ForeignKey("Product")]
        public virtual ProductModel ProductModel { get; set; }

        [JsonIgnore]
        [ForeignKey("Location")]
        public virtual LocationModel LocationModel { get; set; }
    }
}
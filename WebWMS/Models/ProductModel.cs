using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebWMS.Models
{
    public partial class ProductModel
    {
        public ProductModel()
        {

            Picks = new HashSet<PickModel>();
            DeliveryLines = new HashSet<DeliveryLineModel>();
            StockList = new HashSet<StockModel>();
        }

        [Key]
        public string ProdId { get; set; }

        public string ProdState { get; set; }

        public DateTime StateChangeTime { get; set; }

        [JsonIgnore]
        public virtual ICollection<PickModel> Picks { get; set; }

        [JsonIgnore]
        public virtual ICollection<DeliveryLineModel> DeliveryLines { get; set; }

        [JsonIgnore]
        public virtual ICollection<StockModel> StockList { get; set; }
    }
}
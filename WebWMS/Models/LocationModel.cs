using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebWMS.Models
{
    public partial class LocationModel
    {
        public LocationModel()
        {
            StockList = new HashSet<StockModel>();
        }

        [Key]
        public string LocationId { get; set; }

        public string LocState { get; set; }

        public DateTime StateChangeTime { get; set; }

        [JsonIgnore]
        public virtual ICollection<StockModel> StockList { get; set; }
    }
}
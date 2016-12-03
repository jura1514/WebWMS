using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebWMS.Models
{
    public partial class DeliveryModel
    {
        public DeliveryModel()
        {
            DeliveryLines = new HashSet<DeliveryLineModel>();
        }

        [Key]
        public int DeliveryId { get; set; }

        public string Name { get; set; }

        public DateTime ExpectedDate { get; set; }

        public string Customer { get; set; }

        public string State { get; set; }

        public DateTime StateChangeTime { get; set; }

        [JsonIgnore]
        public virtual ICollection<DeliveryLineModel> DeliveryLines { get; set; }

    }
}
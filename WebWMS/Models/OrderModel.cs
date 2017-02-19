using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebWMS.Models
{
    public class OrderModel
    {
        public OrderModel()
        {
            Picks = new HashSet<PickModel>();
        }

        [Key]
        public int OrderId { get; set; }

        public string OrderState { get; set; }

        public string Description { get; set; }

        public DateTime StateChangeTime { get; set; }

        [JsonIgnore]
        public virtual ICollection<PickModel> Picks { get; set; }
    }
}
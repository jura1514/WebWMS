using System;
using System.ComponentModel.DataAnnotations;

namespace WebWMS.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }

        public string OrderState { get; set; }

        public string Description { get; set; }

        public DateTime StateChangeTime { get; set; }
    }
}
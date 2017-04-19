using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace MVCPracticeProject.Models.FoodOrder
{
    public class Order
    {
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 3)]
        [Display(Name="Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(200,MinimumLength = 5)]
        public string Address { get; set; }

        public string Status { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        [Column(TypeName = "Money")]
        public decimal Subtotal { get; set; }

        public virtual List<OrderItem> OrderList { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCPracticeProject.Models.FoodOrder
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string DishName { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
    }
}
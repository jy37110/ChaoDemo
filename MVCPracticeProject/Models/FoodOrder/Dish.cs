using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCPracticeProject.Models.FoodOrder
{
    public class Dish
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        public string Type { get; set; }
    }
}
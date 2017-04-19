using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPracticeProject.Models.Tables
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public float Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Storage> Storages { get; set; }
        public virtual List<Branch> Branches { get; set; }
    }
}
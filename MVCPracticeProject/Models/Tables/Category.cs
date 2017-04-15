using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCPracticeProject.Models.Tables
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)] 
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
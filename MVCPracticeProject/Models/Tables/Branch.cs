using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCPracticeProject.Models.Tables
{
    public class Branch
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        public string Hours { get; set; }
        public bool IsAgency { get; set; }
        public virtual List<Storage> Storages { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
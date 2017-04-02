using System.Collections.Generic;

namespace MVCPracticeProject.Models.Tables
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Hours { get; set; }
        public bool IsAgency { get; set; }
        public virtual List<Storage> Storages { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
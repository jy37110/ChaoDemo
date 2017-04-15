using System.ComponentModel.DataAnnotations;

namespace MVCPracticeProject.Models.Tables
{
    public class Storage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BranchId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Branch Branch { get; set; }
        [Required]
        public int StockQty { get; set; }
    }
}
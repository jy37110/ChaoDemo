using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCPracticeProject.Models.FoodOrder;
using MVCPracticeProject.Models.Tables;

namespace MVCPracticeProject.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Message> Messagese { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Flow> Flows { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
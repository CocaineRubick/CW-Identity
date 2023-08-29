using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyIdentity.Models;

namespace MyIdentity.DAL
{
    public class dbContext : IdentityDbContext
    {
        public dbContext(DbContextOptions options) : base(options) 
        {

        }
            
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //call the base if you are using identity!
            base.OnModelCreating(builder);

        }
    }
}

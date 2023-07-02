using ArshaApp.Core.Models;
using ArshaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ArshaApp.Context
{
    public class ArshaAppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }


        public ArshaAppDbContext(DbContextOptions<ArshaAppDbContext> options) : base(options){

        }
    }
}

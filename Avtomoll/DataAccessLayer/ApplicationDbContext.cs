using Avtomoll.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Avtomoll.DataAccessLayer
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Service> Service { get; set; }
        public DbSet<GroupService> GroupService { get; set; }
        public ApplicationDbContext(DbContextOptions opt) : base (opt)
        { 
            //Database.EnsureCreated();
        }
    }
}
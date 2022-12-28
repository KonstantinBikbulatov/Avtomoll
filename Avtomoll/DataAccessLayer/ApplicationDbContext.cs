using Avtomoll.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Avtomoll.DataAccessLayer
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Service> Service { get; set; }
        public DbSet<GroupService> GroupService { get; set; }
        public DbSet<CarService> CarService { get; set; }
        public DbSet<ClientCar> ClientCar { get; set; }
        public DbSet<ServiceHistory> ServiceHistory { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<ClientService> ClientService { get; set; }
        public DbSet<FeedBack> FeedBack { get; set; }
        public ApplicationDbContext(DbContextOptions opt) : base (opt)
        { 
            //Database.EnsureCreated();
        }
    }
}
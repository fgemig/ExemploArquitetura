using System.IO;
using FG.MusicStore.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FG.MusicStore.Infra.Data.Mappings.Extensions;
using FG.MusicStore.Infra.Data.Mappings;

namespace FG.MusicStore.Infra.Data.Context
{
    public class MusicStoreContext : DbContext
    {
       
        public DbSet<Customer> Customers { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new CustomerMap());            

            base.OnModelCreating(modelBuilder); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()                
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}

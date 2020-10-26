using System.ComponentModel;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ALSaray.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {

           


        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MyDbAcct>()
                .HasIndex(u => u.acctKey)
                .IsUnique();
        }


        public DbSet<Category> categories { get; set; }  

        
        public DbSet<MyDbAcct>   myDbAccts { get; set; }

        public DbSet<Products> products { get; set; }

        public DbSet <Purchase> purchases { get; set; }

       public DbSet <PurchaseItems> purchaseItems { get; set; }



    }
}
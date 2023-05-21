using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class RenteCarDbContext : DbContext
    {
        //Proje hangi veritabanı ile ilişkilendirdiğimiz yer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Sql servera nasıl bağlanacagımızı belirtmemiz yeterli
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RenteCarDb;Trusted_Connection=true");
        }
        //Nesnelerin hangisine karşılık geldiği kod
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UsersK> UsersKs { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}

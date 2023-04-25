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
    }
}

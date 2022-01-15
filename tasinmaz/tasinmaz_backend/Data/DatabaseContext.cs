using tasinmaz_backend.Models;
using Microsoft.EntityFrameworkCore;
namespace tasinmaz_backend

{
    public class DatabaseContext : DbContext
    {


        public DbSet<City> cities { get; set; }
        public DbSet<County> counties { get; set; }

        public DbSet<Kullanici> kullanicilar { get; set; }

        public DbSet<Log> loglar { get; set; }
        public DbSet<Neighborhood> neighborhoods { get; set; }
        
        public DbSet<Tasinmaz> tasinmazlar { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=tasinmaz;Username=postgres;Password=admin");

        }

        protected override void OnModelCreating(ModelBuilder builder)
{
    



}
    }


       


 


}


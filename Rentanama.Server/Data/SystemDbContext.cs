using Microsoft.EntityFrameworkCore;
using Rentanama.Server.Data.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Rentanama.Server.Auth.Model;


namespace Rentanama.Server.Data
{
    public class SystemDbContext : IdentityDbContext<AdvertisementRestUser>
    {
        private readonly IConfiguration Configuration;
      
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<City> Cities { get; set; }

        //  public SystemDbContext(DbContextOptions<SystemDbContext> options)
        //: base(options)
        //  {

        //  }
        public SystemDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("PostgreSQL"));
        }
    }
    
}

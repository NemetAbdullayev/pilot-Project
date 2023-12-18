
using EntityLayer.Concrete.Building;
using EntityLayer.Concrete.Point;
using EntityLayer.Concrete.Road;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace DataAccessLayer.Concrete.Context
{


    public class DatabaseContext : DbContext
    {

        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<PoiFeature> PoiFeatures { get; set; }
        public DbSet<Poi> Poi { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BuildingFeature> BuildingFeatures { get; set; }
        public DbSet<BuildingProperties> BuildingProperties { get; set; }
        public DbSet<Road> Roads { get; set; }
        public DbSet<RoadFeature> RoadFeatures { get; set; }
        public DbSet<RoadProperties> RoadProperties { get; set; }

    }
}

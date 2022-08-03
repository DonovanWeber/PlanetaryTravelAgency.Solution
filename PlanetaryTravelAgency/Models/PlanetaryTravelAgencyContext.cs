using Microsoft.EntityFrameworkCore;

namespace PlanetaryTravelAgency.Models
{
  public class PlanetaryTravelAgencyContext : DbContext 
  {
    public DbSet<Planet> Planets { get; set; }
    public DbSet<Spaceship> Spaceships { get; set; }
    public DbSet<PlanetSpaceship> PlanetSpaceship { get; set; }
    //public DbSet<AstronautSpaceship> AstronautSpaceship { get; set; }
    public PlanetaryTravelAgencyContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}
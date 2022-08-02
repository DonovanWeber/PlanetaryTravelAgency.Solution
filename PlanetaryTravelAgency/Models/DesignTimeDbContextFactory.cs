using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PlanetaryTravelAgency.Models
{
  public class PlanetaryTravelAgencyContextFactory : IDesignTimeDbContextFactory<PlanetaryTravelAgencyContext>
  {

    PlanetaryTravelAgencyContext IDesignTimeDbContextFactory<PlanetaryTravelAgencyContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<PlanetaryTravelAgencyContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new PlanetaryTravelAgencyContext(builder.Options);
    }
  }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RestaurantsCuisines.Models
{
  public class RestaurantCuisineContextFactory : IDesignTimeDbContextFactory<RestaurantCuisineContext>
  {

    RestaurantCuisineContext IDesignTimeDbContextFactory<RestaurantCuisineContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<RestaurantCuisineContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new RestaurantCuisineContext(builder.Options);
    }
  }
}
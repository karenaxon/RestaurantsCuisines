using Microsoft.EntityFrameworkCore;

namespace RestaurantsCuisines.Models
{
  public class RestaurantCuisineContext : DbContext
  {
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Cuisine> Cuisines { get; set; }
    public DbSet<RestaurantCuisine> RestaurantCuisine { get; set; } //each DbSet will become a table in our database
  
    public RestaurantCuisineContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}
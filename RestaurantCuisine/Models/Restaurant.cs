using System.Collections.Generic;

namespace RestaurantsCuisines.Models
{
  public class Restaurant
  {
    public Restaurant()
    {
      this.JoinEntities = new HashSet<RestaurantCuisine>();
    }

    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<RestaurantCuisine> JoinEntities { get; set; }
  }
}
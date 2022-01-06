using System.Collections.Generic;

namespace RestaurantsCuisines.Models
{
  public class Cuisine
  {
    public Cuisine()
    {
      this.JoinEntities = new HashSet<RestaurantCuisine>();
    }
  
  public int CuisineId { get; set; }
  public string Description { get; set; }

  public virtual ICollection<RestaurantCuisine> JoinEntities { get;}

  }
}
namespace RestaurantsCuisines.Models
{
  public class RestaurantCuisine
  {       
    public int RestaurantCuisineId { get; set; }
    public int CuisineId { get; set; }
    public int RestaurantId { get; set; }
    public virtual Cuisine Cuisine { get; set; }
    public virtual Restaurant Restaurant { get; set; }
  }
}
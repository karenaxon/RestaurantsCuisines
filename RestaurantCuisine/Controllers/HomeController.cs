using Microsoft.AspNetCore.Mvc;

namespace RestaurantCuisine.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}
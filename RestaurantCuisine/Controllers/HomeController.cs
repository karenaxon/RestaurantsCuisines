using Microsoft.AspNetCore.Mvc;

namespace RestaurantsCuisines.Controllers
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
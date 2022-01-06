using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RestaurantsCuisines.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantsCuisines.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly RestaurantCuisineContext _db;

    public CuisinesController(RestaurantCuisineContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Cuisines.ToList());
    }

  public ActionResult Create()
    {
      ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisine cuisine, int RestaurantId)
  {
      _db.Cuisines.Add(cuisine);
      _db.SaveChanges();
      if (RestaurantId != 0)
      {
          _db.RestaurantCuisine.Add(new RestaurantCuisine() { RestaurantId = RestaurantId, CuisineId = cuisine.CuisineId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
  }

  public ActionResult Details(int id)
  {
    var thisCuisine = _db.Cuisines
        .Include(cuisine => cuisine.JoinEntities)
        .ThenInclude(join => join.Restaurant)
        .FirstOrDefault(cuisine => cuisine.CuisineId == id);
    return View(thisCuisine);
  }
  
  public ActionResult Edit(int id)
  {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
      return View(thisCuisine);
  }

  [HttpPost]
  public ActionResult Edit(Cuisine cuisine, int RestaurantId)
  {
    if (RestaurantId != 0)
    {
      _db.RestaurantCuisine.Add(new RestaurantCuisine() { RestaurantId = RestaurantId, CuisineId = cuisine.CuisineId });
    }
    _db.Entry(cuisine).State = EntityState.Modified;
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

    public ActionResult Delete(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      _db.Cuisines.Remove(thisCuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult AddRestaurant(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
      return View(thisCuisine);
    }

    [HttpPost]
    public ActionResult AddRestaurant(Cuisine cuisine, int RestaurantId)
    {
      if (RestaurantId != 0)
      {
      _db.RestaurantCuisine.Add(new RestaurantCuisine() { RestaurantId = RestaurantId, CuisineId = cuisine.CuisineId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteRestaurant(int joinId)
      {
      var joinEntry = _db.RestaurantCuisine.FirstOrDefault(entry => entry.RestaurantCuisineId == joinId);
      _db.RestaurantCuisine.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}
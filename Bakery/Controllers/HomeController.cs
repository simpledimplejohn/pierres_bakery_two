// shows that the default without any path will access this

using Microsoft.AspNetCore.Mvc;
using System;

namespace Bakery.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index() //refers to home/Index.cshtml
      {
        return View();
      }
// REMOVE THIS LATER -- JUST FOR TESTING
      [Route("/favorite_photos")] //adding photos from a view page
      public ActionResult FavoritePhotos()
      {
        ViewData["message"] = "this is the message"; //a method called view data
        return View();
      }

    }
}
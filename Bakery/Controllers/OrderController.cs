//home control is the sport where routs are contained for Items

using Microsoft.AspNetCore.Mvc;
using Bakery.Models; //import the namespace that contains all the classes here
using System.Collections.Generic;

namespace Bakery.Controllers
{
  public class OrdersController : Controller //this will search for the sub folder of Views folder named Items
  {

    [HttpGet("/vendors/{vendorId}/orders/new")]  //looks for the items in category
    public ActionResult New(int vendorId) //new page gets something
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }

    [HttpPost("/orders/delete")] //deleteall page, refers to delete button in Items/Index.cshtml
    public ActionResult DeleteAll() //this name has to be the same as .cshtml file
    {
      Order.ClearAll(); //defined in Items.cs
      return View(); // DeleteAll.cshtml
    }

    [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult Show(int vendorId, int orderId)
    {
      Order order = Order.Find(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View(model);
    }
  }
}
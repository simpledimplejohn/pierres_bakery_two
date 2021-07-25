using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Bakery.Models;

namespace Bakery.Controllers
{
  public class VendorsController : Controller //looks in views/Categories
  {

    [HttpGet("/vendors")] 
    public ActionResult Index() // index proute displays all categorys 
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors); //feeds catagories list to page where the page loops through it
    }

    [HttpGet("/vendors/new")]
    public ActionResult New() 
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string vendorName, string vendorDescription) // comes from New.cshtml even though its called create
    {
      Vendor newVendor = new Vendor(vendorName, vendorDescription);
      return RedirectToAction("Index"); //after category is created sends us back to index
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id) //the details page that has the details of the category 
    {
      Dictionary<string, object> model = new Dictionary<string, object>(); //view can only accept one model argument, pass into temporary dictionary
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> vendorOrders = selectedVendor.Orders;
      model.Add("vendor", selectedVendor); //???what does the string do????
      model.Add("orders", vendorOrders);
      return View(model);
    }


    // This one creates new Items within a given Category, not new Categories:

    [HttpPost("/vendors/{vendorId}/orders")] 
    public ActionResult Create(int vendorId, string orderDescription, string orderTitle, int orderPrice)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.Find(vendorId); // grabs the category
      Order newOrder = new Order(orderDescription, orderTitle, orderPrice); // grabs the item 
      foundVendor.AddOrder(newOrder);  //adds the item to the category
      List<Order> vendorOrders = foundVendor.Orders; 
      model.Add("orders", vendorOrders); //add to dictionary
      model.Add("vendor", foundVendor); //add to dictionary
      return View("Show", model); //return the dictionary (show???)
    }

  }
}
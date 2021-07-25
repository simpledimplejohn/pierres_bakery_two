using System.Collections.Generic; // so we can use lists

namespace Bakery.Models
{
  public class Vendor
  {
    private static List<Vendor> _instances = new List<Vendor> {}; //this _instance will contain the category list
    public string Name { get; set; } // name of the category
    public string Description { get; set; }
    public int Id { get; }
    public List<Order> Orders { get; set; } // adding from the Items.cs file auto-implemented property

    public Vendor(string vendorName, string vendorDescription) // this makes the constructor with above info put in
    {
      Name = vendorName; //each of these is a _instance of the category list
      Description = vendorDescription;
      _instances.Add(this); // adding the category instance to the category list from line 7
      Id = _instances.Count;
      Orders = new List<Order>{}; //instatiates the Item list thats inside this category _instance autoimplemented property for Itmes
    }

    public static void ClearAll()
    {
      _instances.Clear(); //static because its not something we need except for testing?  or applys to all catagory instance
    }

    public static List<Vendor> GetAll()
    {
      return _instances;
    }

    public static Vendor Find(int searchId)
    {
      return _instances[searchId-1]; //_instance is the category which is an Item list
    }

    public void AddOrder(Order order) 
    {
      Orders.Add(order); // this adding Items to Items list in Category
    }

  }
}
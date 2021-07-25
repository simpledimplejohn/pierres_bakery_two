using System.Collections.Generic;

namespace Bakery.Models
{
  public class Order // definition of what a thing will have (is our constructor) (is our object)
  {
    public string Title { get; set; }
    public string Description { get; set; } // object property
    public int Price { get; set; }
    public int Id { get; } // object property
    private static List<Order> _instances = new List<Order> { }; //_instance is the list, Item = descrition + list

    public Order(string description, string title, int price)
    {
      Description = description;
      Title = title;
      Price = price;
      _instances.Add(this); //this refers to the Item in the constructor
      Id = _instances.Count; //gets the Id count an dmakes it accesable
    }

    public static List<Order> GetAll() //a list function that returns the list Item
    {
      return _instances;
    }

    public static void ClearAll() // our method
    {
      _instances.Clear(); // built in method
    }
    public static Order Find(int searchId) // static --must sift through all Items
    {
      return _instances[searchId-1]; //subtract 1 to get right number of array
    }
  }
}
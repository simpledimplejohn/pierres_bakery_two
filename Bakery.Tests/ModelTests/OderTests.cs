using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models;
using System.Collections.Generic;

namespace Bakery.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("test", "test", 1, "test");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsTitle_String()
    {
      string title = "giant pie";
      string description = "biggest pie we have";
      int price = 50;
      string date = "1/1/2050";
      Order newOrder = new Order(title, description, price, date);

      string result = newOrder.Title;

      Assert.AreEqual(title, result);
    }

    [TestMethod]
    public void SetTitle_SetTitle_string()
    {
      string title = "giant pie";
      string description = "biggest pie we have";
      int price = 50;
      string date = "1/1/2050";
      Order newOrder = new Order(title, description, price, date);

      string updateTitle = "Giant Pie!";
      newOrder.Title = updateTitle;
      string result = newOrder.Title;

      Assert.AreEqual(updateTitle, result);
    }

    [TestMethod]
    public void GetAll_ReturnEmptyList_OrderList()
    {
      List<Order> newList = new List<Order> {};
      
      List<Order> result = Order.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnOrders_OrderList()
    {
      string title1 = "giant pie";
      string description1 = "biggest pie we have";
      int price1 = 50;
      string date1 = "1/1/2050";
      Order newOrder1 = new Order(title1, description1, price1, date1);
      string title2 = "tiny pie";
      string description2 = "smallest pie we have";
      int price2 = 1;
      string date2 = "1/1/2050";
      Order newOrder2 = new Order(title2, description2, price2, date2);
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };

      List<Order> result = Order.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_OrderInstantiateWithAnIdAndGetterReturns_Int()
    {
      string title1 = "giant pie";
      string description1 = "biggest pie we have";
      int price1 = 50;
      string date1 = "1/1/2050";
      Order newOrder1 = new Order(title1, description1, price1, date1);
      string title2 = "tiny pie";
      string description2 = "smallest pie we have";
      int price2 = 1;
      string date2 = "1/1/2050";
      Order newOrder2 = new Order(title2, description2, price2, date2);
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };

      Order result = Order.Find(2);

      Assert.AreEqual(newOrder2, result);
    }
  }
}
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
  }
}
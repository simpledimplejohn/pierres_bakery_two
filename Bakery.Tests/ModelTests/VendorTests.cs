using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models;
using System.Collections.Generic;
using System;

namespace Bakery.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }
    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("test name", "test description");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "test vendor";
      string description = "test description";
      Vendor newVendor = new Vendor(name, description);
      string result = newVendor.Name;
      Assert.AreEqual(name, result);
    }
    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      string name = "test vendor";
      string description = "test description";
      Vendor newVendor = new Vendor(name, description);
      string result = newVendor.Description;
      Assert.AreEqual(description, result);
    }
    [TestMethod]
    public void GetId_ReturnsVendorID_Int()
    {
      string name = "test vendor";
      string description = "test description";
      Vendor newVendor = new Vendor(name, description);

      int result = newVendor.Id;

      Assert.AreEqual(1, result);
    }
    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_VendorList()
    {
      string name1 = "test vendor1";
      string description1 = "test description1";
      Vendor newVendor1 = new Vendor(name1, description1);
      string name2 = "test vendor2";
      string description2 = "test description2";
      Vendor newVendor2 = new Vendor(name2, description2);
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

      List<Vendor> result = Vendor.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      string name1 = "test vendor1";
      string description1 = "test description1";
      Vendor newVendor1 = new Vendor(name1, description1);
      string name2 = "test vendor2";
      string description2 = "test description2";
      Vendor newVendor2 = new Vendor(name2, description2);

      Vendor result = Vendor.Find(2);

      Assert.AreEqual(newVendor2, result);
    }
    [TestMethod]
    public void AddOrder_AssociatesOrderWithVendor_OrderList()
    {
      string name = "giant pie";
      string description = "the biggest pie we make";
      int price = 50;
      string date = "11/12/2060";
      Order newOrder = new Order(name, description, price, date);
      List<Order> newList = new List<Order> { newOrder };
      string vendorName = "John's Pies";
      string vendorDescription = "a great pie place";
      Vendor newVendor = new Vendor(vendorName, vendorDescription);
      newVendor.AddOrder(newOrder);

      List<Order> result = newVendor.Orders;

      CollectionAssert.AreEqual(newList, result);
    }
  }
}
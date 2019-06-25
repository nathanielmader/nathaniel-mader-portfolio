using Flooring.Data;
using Flooring.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Tests
{
    [TestFixture]
    public class FileOrderTests
    {

        private const string _filePath = @"F:\REPO\Flooring\Flooring.UI\TestData\Order_0.txt";//Original data //@"\\Mac\Home\Desktop\SGFlooring\Flooring.UI\Flooring.Tests\bin\Debug\ProdDataSEED.txt"
        private const string _path = @"F:\REPO\Flooring\Flooring.UI\TestData";



        //[Test]
        //public void CanReadDataFromFile()
        //{
        //    OrderFileRepository repo = new OrderFileRepository(_filePath);

        //    string date = "02/02/2017";
        //    DateTime orderDate = DateTime.Parse(date);

        //    List<Order> orderList = repo.LoadOrders(orderDate);

        //    Assert.AreEqual(1, orderList.Count());
        //}


        [Test]
        public void CanAddOrderToFile()
        {
            OrderFileRepository repo = new OrderFileRepository(_path);

            Order newOrder = new Order();
            string date = "02/02/2017";

            newOrder.OrderDate = DateTime.Parse(date);
            newOrder.CustomerName = "Lord Bad GUY";
            newOrder.State = "PA";
            newOrder.TaxRate = 6.75M;
            newOrder.ProductType = "Carpet";
            newOrder.Area = 100M;
            newOrder.CostPerSquareFoot = 2.25M;
            newOrder.LaborCostPerSquareFoot = 2.10M;
            newOrder.MaterialCost = 225M;
            newOrder.LaborCost = 210M;
            newOrder.Tax = 29.3625M;
            newOrder.Total = 464.3625M;


            repo.AddOrder(newOrder);

            List<Order> orderList = repo.LoadOrders(newOrder.OrderDate);
            Assert.AreEqual(1, orderList.Count());

            Order check = repo.RetrieveSingleOrder(newOrder.OrderDate, newOrder.OrderNumber);

            Assert.AreEqual("02/02/2017", check.OrderDate.ToString("MMddyyyy"));
            Assert.AreEqual(2, check.OrderNumber);
            Assert.AreEqual("Lord Bad GUY", check.CustomerName);
            Assert.AreEqual("PA", check.State);
            Assert.AreEqual(6.75, check.TaxRate);
            Assert.AreEqual("Carpet", check.ProductType);
            Assert.AreEqual(100, check.Area);
            Assert.AreEqual(2.25, check.CostPerSquareFoot);
            Assert.AreEqual(2.10, check.LaborCostPerSquareFoot);
            Assert.AreEqual(225, check.MaterialCost);
            Assert.AreEqual(210, check.LaborCost);
            Assert.AreEqual(29.3625, check.Tax);
            Assert.AreEqual(464.3625, check.Total);
        }

        //[Test]
        //public void EditOrderFile()
        //{

        //}

        //[Test]
        //public void RemoveOrderFile()
        //{
        //    OrderFileRepository repo = new OrderFileRepository();

        //    repo.RemoveOrder()
        //}
    }
}

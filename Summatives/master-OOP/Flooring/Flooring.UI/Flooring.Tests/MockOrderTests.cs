using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL;
using Flooring.Data;
using Flooring.Models;
using Flooring.Models.Responses;
using NUnit.Framework;

namespace Flooring.Tests
{
    [TestFixture]
    public class MockOrderTests
    {
        [Test]
        public void CanRetrieveSingleOrderTest()
        {
            Manager manager = ManagerFactory.Create();

            DateTime date = DateTime.Parse("03 / 01 / 2026");

            OrderResponse response = manager.RetrieveOrder(date, 4);

            Assert.IsTrue(response.Success);
            Assert.AreEqual("Weber", response.Order.CustomerName);
            Assert.AreEqual(4.15M, response.Order.LaborCostPerSquareFoot);
            Assert.AreNotEqual("MI", response.Order.State);
        }

        [Test]
        public void CanAddOrderTest()
        {
            Manager manager = ManagerFactory.Create();

            OrderTestRepository repo = new OrderTestRepository();

            Order orderToAdd = new Order()
            {
                OrderDate = DateTime.Parse("07/01/2019"),
                CustomerName = "James",
                State = "MI",
                TaxRate = 5.75M,
                ProductType = "Carpet",
                Area = 100.00M,
                CostPerSquareFoot = 2.25M,
                LaborCostPerSquareFoot = 2.10M
            };

            Order order = manager.CreateNewOrder(orderToAdd.OrderDate, orderToAdd.CustomerName, orderToAdd.State, orderToAdd.ProductType, orderToAdd.Area);
            manager.AddOrder(order);

            List<Order> orderList = repo.LoadOrders(order.OrderDate);

            Assert.AreEqual(225, order.MaterialCost);
            Assert.AreEqual(3, orderList.Count());
        }

        //[Test]
        //public void CanRemoveOrderTest()
        //{
        //    Manager manager = ManagerFactory.Create();

        //    OrderTestRepository repo = new OrderTestRepository();

        //    Order orderToAdd = new Order()
        //    {
        //        OrderDate = DateTime.Parse("05/14/2034"),
        //        CustomerName = "Henry That One Guy",
        //        State = "MI",
        //        TaxRate = 5.75M,
        //        ProductType = "Carpet",
        //        Area = 100.00M,
        //        CostPerSquareFoot = 2.25M,
        //        LaborCostPerSquareFoot = 2.10M
        //    };

        //    Order oldOrder = manager.CreateNewOrder(orderToAdd.OrderDate, orderToAdd.CustomerName, orderToAdd.State, orderToAdd.ProductType, orderToAdd.Area);
        //    manager.AddOrder(oldOrder);
        //    List<Order> orderList = repo.LoadOrders(oldOrder.OrderDate);

        //    Assert.AreEqual(2, orderList.Count());

        //    //foreach (var order in orderList)
        //    //{

        //    //}

        //    manager.DeleteOrder(oldOrder);
        //    List<Order> list = repo.LoadOrders(oldOrder.OrderDate);
        //    Assert.AreEqual(1, orderList.Count());
        //    //Assert.IsNull(response.Order);
        //}


        //[Test]
        //public void CanUpdateOrderTest()
        //{
        //    Manager manager = ManagerFactory.Create();

        //    OrderTestRepository repo = new OrderTestRepository();

        //    Order orderToEdit = new Order()
        //    {

        //        OrderDate = DateTime.Parse("07/01/2019"),
        //        CustomerName = "James",
        //        State = "MI",
        //        TaxRate = 5.75M,
        //        ProductType = "Carpet",
        //        Area = 100.00M,
        //        CostPerSquareFoot = 2.25M,
        //        LaborCostPerSquareFoot = 2.10M
        //    };

        //    Order order = manager.CreateNewOrder(orderToEdit.OrderDate, orderToEdit.CustomerName, orderToEdit.State, orderToEdit.ProductType, orderToEdit.Area);
        //    manager.AddOrder(order);

        //    List<Order> orderList = repo.LoadOrders(order.OrderDate);

        //    Assert.AreEqual();
        //    Assert.AreEqual();
        //    Assert.AreEqual(225, order.MaterialCost);
        //    Assert.AreEqual(3, orderList.Count());
        //}
    }
}


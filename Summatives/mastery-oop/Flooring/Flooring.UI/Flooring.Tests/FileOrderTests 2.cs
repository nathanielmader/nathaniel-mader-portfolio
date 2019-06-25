using Flooring.Data;
using Flooring.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Tests
{
    [TestFixture]
    public class FileOrderTests
    {
        [Test]
        public void CanReadDataFromFile()
        {
            OrderFileRepository repo = new OrderFileRepository(@"ProdDataSEED.txt");

            string date = "01/01/2025";
            DateTime orderDate = DateTime.Parse(date);

            List<Order> orderList = repo.LoadOrders(orderDate);

            Assert.AreEqual(1, orderList.Count());
        }
    }
}

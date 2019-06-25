using Flooring.Models;
using Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class OrderFileRepository : IOrderRepository
    {

        //New file created each sales day. Date is part of file name, new file name should be: Orders_MMDDYYYY.txt
        private string _filePath;

        public OrderFileRepository(string filePath)//To change between test and prod files
        {
            _filePath = filePath;
        }

        public void AddOrder(Order order)
        {
            var orderList = LoadOrders(order.OrderDate);

            if (orderList.Count == 0)
            {
                order.OrderNumber = 1;
            }
            else
            {
                order.OrderNumber = orderList.Max(x => x.OrderNumber) + 1;
            }
            orderList.Add(order);
            CreateOrderFile(orderList.OrderBy(x => x.OrderNumber).ToList(), order.OrderDate);
        }

        public List<Order> LoadOrders(DateTime orderDate)
        {
            string orderName = "Order_" + orderDate.ToString("MMddyyyy") + ".txt";

            List<Order> orderList = new List<Order>();
            if (File.Exists(_filePath + orderName) == false)
            {
                return orderList;
            }

            using (StreamReader sr = new StreamReader(_filePath + orderName))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Order newOrder = new Order();

                    string[] columns = line.Split(',');

                    newOrder.OrderDate = orderDate;
                    newOrder.OrderNumber = int.Parse(columns[0]);
                    newOrder.CustomerName = columns[1];
                    newOrder.State = columns[2];
                    newOrder.TaxRate = decimal.Parse(columns[3]);
                    newOrder.ProductType = columns[4];
                    newOrder.Area = decimal.Parse(columns[5]);
                    newOrder.CostPerSquareFoot = decimal.Parse(columns[6]);
                    newOrder.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                    newOrder.MaterialCost = decimal.Parse(columns[8]);
                    newOrder.LaborCost = decimal.Parse(columns[9]);
                    newOrder.Tax = decimal.Parse(columns[10]);
                    newOrder.Total = decimal.Parse(columns[11]);

                    orderList.Add(newOrder);
                }
            }
            return orderList;
        }

        public void RemoveOrder(Order order)
        {
            string fileName = "Order_" + order.OrderDate.ToString("MMddyyyy") + ".txt";

            List<Order> orderList = LoadOrders(order.OrderDate);

            for (int i = 0; i < orderList.Count(); i++)
            {
                if (orderList[i].OrderNumber == order.OrderNumber && orderList[i].OrderDate == order.OrderDate)
                {
                    orderList.Remove(orderList[i]);
                }

            }
            if (orderList.Count == 0)
            {
                File.Delete(_filePath + fileName);
            }
            else
            {
                CreateOrderFile(orderList.OrderBy(x => x.OrderNumber).ToList(), order.OrderDate);
            }

        }

        public Order RetrieveSingleOrder(DateTime orderDate, int orderNumber)
        {
            List<Order> list = LoadOrders(orderDate);

            foreach (var order in list)
            {
                if (order.OrderDate == orderDate && order.OrderNumber == orderNumber)
                {
                    return order;
                }
            }

            return null;
        }

        public Order UpdateOrder(Order order)
        {
            List<Order> orderList = LoadOrders(order.OrderDate);

            for (int i = 0; i < orderList.Count(); i++)
            {
                if (orderList[i].OrderNumber == order.OrderNumber && orderList[i].OrderDate == order.OrderDate)
                {
                    orderList.Remove(orderList[i]);
                    orderList.Add(order);
                }

            }
            CreateOrderFile(orderList.OrderBy(x => x.OrderNumber).ToList(), order.OrderDate);
            return order;
        }

        private string CreateCSVForOrder(Order order)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", order.OrderNumber, order.CustomerName, order.State, order.TaxRate, order.ProductType, order.Area, order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total);
        }

        private void CreateOrderFile(List<Order> orderList, DateTime orderDate)
        {
            string fileName = "Order_" + orderDate.ToString("MMddyyyy") + ".txt";

            if (File.Exists(_filePath + fileName))
                File.Delete(_filePath + fileName);

            using (StreamWriter sr = new StreamWriter(_filePath + fileName))
            {
                sr.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach (var order in orderList)
                {
                    sr.WriteLine(CreateCSVForOrder(order));
                }
            }

        }
    }
}

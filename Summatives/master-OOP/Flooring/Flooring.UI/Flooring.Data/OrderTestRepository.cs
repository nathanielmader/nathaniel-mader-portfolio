using Flooring.Models;
using Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class OrderTestRepository : IOrderRepository
    {
        //Private Static, every time we close app, program data resets.

        public static List<Order> _orderList = new List<Order>()
        {
            new Order
            {
                OrderDate = DateTime.Parse("09/01/2019"),
                OrderNumber = 1,
                CustomerName = "Wise",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475.00M,
                Tax = 61.88M,
                Total = 1051.88M
            },

            new Order
            {
                OrderDate = DateTime.Parse("07/01/2019"),
                OrderNumber = 2,
                CustomerName = "Mader",
                State = "MI",
                TaxRate = 5.75M,
                ProductType = "Carpet",
                Area = 100.00M,
                CostPerSquareFoot = 2.25M,
                LaborCostPerSquareFoot = 2.10M,
                MaterialCost = 225M,
                LaborCost = 210M,
                Tax = 25.01M,
                Total = 457.01M
            },
            new Order
            {
                OrderDate = DateTime.Parse("07/01/2019"),
                OrderNumber = 3,
                CustomerName = "Leonidas",
                State = "IN",
                TaxRate = 6.00M,
                ProductType = "Laminate",
                Area = 100.00M,
                CostPerSquareFoot = 1.75M,
                LaborCostPerSquareFoot = 2.10M,
                MaterialCost = 175M,
                LaborCost = 210M,
                Tax = 23.10M,
                Total = 408.10M
            },
            new Order
            {
                OrderDate = DateTime.Parse("03/01/2026"),
                OrderNumber = 4,
                CustomerName = "Weber",
                State = "PA",
                TaxRate = 6.75M,
                ProductType = "Tile",
                Area = 100.00M,
                CostPerSquareFoot = 3.50M,
                LaborCostPerSquareFoot = 4.15M,
                MaterialCost = 350M,
                LaborCost = 415M,
                Tax = 51.64M,
                Total = 816.64M
            },
            new Order
            {
                OrderDate = DateTime.Parse("03/01/2026"),
                OrderNumber = 5,
                CustomerName = "BOBHOPE",
                State = "PA",
                TaxRate = 6.75M,
                ProductType = "Tile",
                Area = 100.00M,
                CostPerSquareFoot = 3.50M,
                LaborCostPerSquareFoot = 4.15M,
                MaterialCost = 350M,
                LaborCost = 415M,
                Tax = 51.64M,
                Total = 816.64M
            },
            new Order
            {
                OrderDate = DateTime.Parse("05/14/2034"),
                OrderNumber = 6,
                CustomerName = "Franklin",
                State = "PA",
                TaxRate = 6.75M,
                ProductType = "Tile",
                Area = 100.00M,
                CostPerSquareFoot = 3.50M,
                LaborCostPerSquareFoot = 4.15M,
                MaterialCost = 350M,
                LaborCost = 415M,
                Tax = 51.64M,
                Total = 816.64M
            },
        };
        public void AddOrder(Order order)
        {
            _orderList.Add(order);
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

        public List<Order> LoadOrders(DateTime orderDate)
        {
            List<Order> list = new List<Order>();

            list = _orderList.FindAll(x => x.OrderDate == orderDate);

            return list;
        }

        public void RemoveOrder(Order order)
        {
            Order orderToDelete = _orderList.Single(x => x.OrderDate == order.OrderDate && x.OrderNumber == order.OrderNumber);//One object in list that matche both date and number.

            _orderList.Remove(orderToDelete);
        }

        //Take all parts, plus new order info, loop list, find order, replace, save
        public Order UpdateOrder(Order newOrder)
        {
            for (int i = 0; i < _orderList.Count(); i++)
            {
                if (_orderList[i].OrderNumber == newOrder.OrderNumber && _orderList[i].OrderDate == newOrder.OrderDate)
                {
                    _orderList.Remove(_orderList[i]);
                }
            }
            _orderList.Add(newOrder);

            return newOrder;
        }
    }
}

using Flooring.Models;
using Flooring.Models.Interfaces;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL
{
    public class Manager
    {
        IOrderRepository _orderRepository;
        IProductRepository _productRepository;
        IStateRepository _stateRepository;

        public Manager(IOrderRepository orderRepository, IProductRepository productRepository, IStateRepository stateRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _stateRepository = stateRepository;
        }

        public OrderResponse AddOrder(Order order)
        {
            OrderResponse response = new OrderResponse();

            response.Order = order;

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"Error. Unable to add order. Contact IT.";
            }
            else
            {
                response.Success = true;
                _orderRepository.AddOrder(order);
            }
            return response;
        }

        public OrderResponse DeleteOrder(Order order)
        {
            OrderResponse response = new OrderResponse();

            response.Order = order;

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"Error. Unable to remove order. Contact IT.";
            }
            else
            {
                response.Success = true;
                _orderRepository.RemoveOrder(order);
            }
            return response;
        }

        public OrderResponse RetrieveOrder(DateTime orderDate, int orderNumber)
        {
            OrderResponse response = new OrderResponse();

            response.Order = _orderRepository.RetrieveSingleOrder(orderDate, orderNumber);

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"Error. Unable to locate order with order number {orderNumber} on {orderDate}. Contact IT.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public DisplayOrdersResponse DisplayOrders(DateTime orderDate)
        {
            DisplayOrdersResponse response = new DisplayOrdersResponse();

            response.Orders = _orderRepository.LoadOrders(orderDate);

            if (response.Orders == null)
            {
                response.Success = false;
                response.Message = "Orders not found.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public DisplayStatesResponse DisplayStateList()
        {
            DisplayStatesResponse response = new DisplayStatesResponse();//returns list of states, success(bool), message(string)

            response.States = _stateRepository.LoadStates();//set response list of (States) to repo load states method(returns list)

            if (response.States.Count == 0)//if empty list
            {
                response.Success = false;
                response.Message = "Error. No states found.";
            }
            else
            {
                response.Success = true;
            }
            return response;//return list
        }

        public StateCheckResponse StateCheckAbbreviationEntry(string stateAbbreviation)
        {
            StateCheckResponse response = new StateCheckResponse();

            List<Taxes> stateList = _stateRepository.LoadStates();

            response.StateAbbreviationToCheck = stateAbbreviation;

            foreach (var state in stateList)
            {
                if (state.StateAbbreviation == response.StateAbbreviationToCheck)
                {
                    response.Success = true;
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Error. This is not a state we service.";
                }
            }
            return response;
        }


        public CheckProductResponse CheckProductTypeEntry(string productType)
        {
            CheckProductResponse response = new CheckProductResponse();

            List<Products> productList = _productRepository.LoadProducts();

            response.ProductTypeToCheck = productType;

            foreach (var product in productList)
            {
                if (product.ProductType == response.ProductTypeToCheck)
                {
                    response.Success = true;
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Error.";
                }
            }
            return response;
        }
        public DisplayProductsResponse DisplayProductList()
        {
            DisplayProductsResponse response = new DisplayProductsResponse();

            response.Products = _productRepository.LoadProducts();

            if (response.Products.Count == 0)
            {
                response.Success = false;
                response.Message = "Error. No Products found.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        //Create/Add Order-query for each piece
        //Remaining fields calculated
        public Order CreateNewOrder(DateTime orderDate, string customerName, string stateAB, string productType, decimal area)
        {
            Order orderToCreate = new Order();
            List<Order> orderList = _orderRepository.LoadOrders(orderDate);//Returns list of orders with same order date
            List<Products> productList = _productRepository.LoadProducts();
            List<Taxes> stateList = _stateRepository.LoadStates();

            decimal newTaxRate = stateList.Single(x => x.StateAbbreviation == stateAB).TaxRate;
            decimal newCostPerSquareFoot = productList.Single(x => x.ProductType == productType).CostPerSquareFoot;
            decimal newLaborCostPerSquareFoot = productList.Single(x => x.ProductType == productType).LaborCostPerSquareFoot;

            Order newOrder = new Order()
            {

                OrderDate = orderDate,//
                OrderNumber = orderList.Select(x => x.OrderNumber).DefaultIfEmpty().Max() + 1,//Currently displays new order number for date.
                CustomerName = customerName,//
                State = stateAB,//
                TaxRate = newTaxRate,
                ProductType = productType,//
                Area = area,//
                CostPerSquareFoot = newCostPerSquareFoot,
                LaborCostPerSquareFoot = newLaborCostPerSquareFoot,
                MaterialCost = area * newCostPerSquareFoot,
                LaborCost = area * newLaborCostPerSquareFoot,
                Tax = (((area * newCostPerSquareFoot) + (area * newLaborCostPerSquareFoot)) * (newTaxRate / 100)),
                Total = (area * newCostPerSquareFoot) + (area * newLaborCostPerSquareFoot) + ((((area * newCostPerSquareFoot) + (area * newLaborCostPerSquareFoot)) * (newTaxRate / 100))), //Very inefficient but idc
            };

            orderToCreate = newOrder;
            return orderToCreate;
        }

        //Same as Create, apart from ordernumber info (order number cannot change)....
        public Order UpdateOrder(DateTime orderDate, int orderNumber, string customerName, string stateAB, string productType, decimal area)
        {
            Order orderToUpdate = _orderRepository.RetrieveSingleOrder(orderDate, orderNumber);

            List<Products> productList = _productRepository.LoadProducts();
            List<Taxes> stateList = _stateRepository.LoadStates();

            decimal newTaxRate = stateList.Single(x => x.StateAbbreviation == stateAB).TaxRate;
            decimal newCostPerSquareFoot = productList.Single(x => x.ProductType == productType).CostPerSquareFoot;
            decimal newLaborCostPerSquareFoot = productList.Single(x => x.ProductType == productType).LaborCostPerSquareFoot;

            Order newOrder = new Order()
            {
                OrderDate = orderDate,//
                OrderNumber = orderNumber,//
                CustomerName = customerName,//
                State = stateAB,//
                TaxRate = newTaxRate,
                ProductType = productType,//
                Area = area,//
                CostPerSquareFoot = newCostPerSquareFoot,
                LaborCostPerSquareFoot = newLaborCostPerSquareFoot,
                MaterialCost = area * newCostPerSquareFoot,
                LaborCost = area * newLaborCostPerSquareFoot,
                Tax = (((area * newCostPerSquareFoot) + (area * newLaborCostPerSquareFoot)) * (newTaxRate / 100)),
                Total = (area * newCostPerSquareFoot) + (area * newLaborCostPerSquareFoot) + ((((area * newCostPerSquareFoot) + (area * newLaborCostPerSquareFoot)) * (newTaxRate / 100))), //Very inefficient but idc
            };

            orderToUpdate = newOrder;
            _orderRepository.UpdateOrder(orderToUpdate);
            return orderToUpdate;
        }
        public Order CalculateDisplayUpdateOrder(DateTime orderDate, int orderNumber, string customerName, string stateAB, string productType, decimal area)
        {
            Order orderToUpdate = _orderRepository.RetrieveSingleOrder(orderDate, orderNumber);

            List<Products> productList = _productRepository.LoadProducts();
            List<Taxes> stateList = _stateRepository.LoadStates();

            decimal newTaxRate = stateList.Single(x => x.StateAbbreviation == stateAB).TaxRate;
            decimal newCostPerSquareFoot = productList.Single(x => x.ProductType == productType).CostPerSquareFoot;
            decimal newLaborCostPerSquareFoot = productList.Single(x => x.ProductType == productType).LaborCostPerSquareFoot;

            Order newOrder = new Order()
            {
                OrderDate = orderDate,//
                OrderNumber = orderNumber,//
                CustomerName = customerName,//
                State = stateAB,//
                TaxRate = newTaxRate,
                ProductType = productType,//
                Area = area,//
                CostPerSquareFoot = newCostPerSquareFoot,
                LaborCostPerSquareFoot = newLaborCostPerSquareFoot,
                MaterialCost = area * newCostPerSquareFoot,
                LaborCost = area * newLaborCostPerSquareFoot,
                Tax = (((area * newCostPerSquareFoot) + (area * newLaborCostPerSquareFoot)) * (newTaxRate / 100)),
                Total = (area * newCostPerSquareFoot) + (area * newLaborCostPerSquareFoot) + ((((area * newCostPerSquareFoot) + (area * newLaborCostPerSquareFoot)) * (newTaxRate / 100))), //Very inefficient but idc
            };

            orderToUpdate = newOrder;
            //_orderRepository.UpdateOrder(orderToUpdate);
            return orderToUpdate;
        }
    }
}

using Flooring.Models;
using Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class ProductTestRepository : IProductRepository
    {
        private static List<Products> _productList = new List<Products>()
        {
            new Products
            {
                ProductType = "Carpet",
                CostPerSquareFoot = 2.25M,
                LaborCostPerSquareFoot = 2.10M
            },
            new Products
            {
                ProductType = "Laminate",
                CostPerSquareFoot = 1.75M,
                LaborCostPerSquareFoot = 2.10M
            },
            new Products
            {
                ProductType = "Tile",
                CostPerSquareFoot = 3.50M,
                LaborCostPerSquareFoot = 4.15M
            },
            new Products
            {
                ProductType = "Wood",
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M
            }
        };
        public List<Products> LoadProducts()
        {
            List<Products> productList = new List<Products>();

            productList = _productList;

            return productList;
        }
    }
}

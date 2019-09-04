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
    public class ProductFileRepository : IProductRepository
    {
        private string _filePath = @"Products.txt";

        public List<Products> LoadProducts()
        {
            string file = _filePath;

            List<Products> ListOfProducts = new List<Products>();

            using (StreamReader sr = new StreamReader(file))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Products newProduct = new Products();
     
                    string[] columns = line.Split(',');

                    newProduct.ProductType = columns[0];
                    newProduct.CostPerSquareFoot = decimal.Parse(columns[1]);
                    newProduct.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                    ListOfProducts.Add(newProduct);
                }
            }
            return ListOfProducts;
        }
    }
}

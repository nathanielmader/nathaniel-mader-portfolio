using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMast.Models.ViewModels
{
    public class InventoryDetailsViewModel
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public int Model { get; set; }
        public int Count { get; set; }
        public decimal StockValue { get; set; }
    }
}

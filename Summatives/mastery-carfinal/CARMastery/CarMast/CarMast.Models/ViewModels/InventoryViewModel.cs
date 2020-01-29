using CarMast.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMast.Models.ViewModels
{
    public class InventoryViewModel
    {
        public List<Vehicle> NewVehicles { get; set; }
        public List<Vehicle> UsedVehicles { get; set; }
        public List<InventoryDetailsViewModel> Details { get; set; }
    }
}

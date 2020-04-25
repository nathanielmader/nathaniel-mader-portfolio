using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARMASTERY.Models.ViewModels
{
    public class InventoryViewModel
    {
        public List<InventoryDetailsViewModel> NewVehicles { get; set; }
        public List<InventoryDetailsViewModel> UsedVehicles { get; set; }
    }
}

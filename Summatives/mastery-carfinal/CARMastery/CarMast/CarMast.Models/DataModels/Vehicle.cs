using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMast.Models.DataModels
{
    public class Vehicle
    {
        //Changed, need to update database
        public int VehicleId { get; set; }
        public string VehicleDescription { get; set; }
        public int VehicleTypeId { get; set; }
        public int ModelId { get; set; }
        public int TransmissionId { get; set; }
        public int BodyStyleId { get; set; }
        public int ExteriorColorId { get; set; }
        public int InteriorColorId { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        public int Year { get; set; }
        public string Vin { get; set; }
        public int Mileage { get; set; }
        public bool Featured { get; set; }
        public bool SoldOut { get; set; }
        public string ImageFileName { get; set; }

        public virtual VehicleType VehicleType { get; set; }
        public virtual Model Model { get; set; }
        public virtual ExteriorColor ExteriorColor { get; set; }
        public virtual InteriorColor InteriorColor { get; set; }
        public virtual Transmission Transmission { get; set; }
        public virtual BodyStyle BodyStlye { get; set; }
    }
}

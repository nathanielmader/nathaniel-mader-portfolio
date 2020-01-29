using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMast.Models.DataModels
{
    public class Contact
    {
        public int ContactId { get; set; }

        //Required
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //Required
        public string Message { get; set; }
        //If contact button in Inv/Details page used, need to place VIN# of vehicle 
        public int? VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}

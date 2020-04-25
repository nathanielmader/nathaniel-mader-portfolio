using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARMASTERY.Models.DataModels
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
        public int? VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}

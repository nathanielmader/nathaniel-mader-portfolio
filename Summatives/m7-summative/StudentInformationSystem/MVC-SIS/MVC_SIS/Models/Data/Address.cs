using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Address
    {
        public int AddressId { get; set; }

        [Required(ErrorMessage = "Please enter a valid street")]
        public string Street1 { get; set; }
        public string Street2 { get; set; }

        [Required(ErrorMessage = "Please enter a city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state")]
        public State State { get; set; }

        [Required(ErrorMessage = "Please enter a postal code")]
        public string PostalCode { get; set; }
    }
}
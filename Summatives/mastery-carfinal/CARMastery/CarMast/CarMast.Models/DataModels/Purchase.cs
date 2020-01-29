using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMast.Models.DataModels
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime DatePurchased { get; set; }

        public int PurchaseTypeId { get; set; }
        public int StateId { get; set; }
        public int VehicleId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual State State { get; set; }
        public virtual PurchaseType PurchaseType { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}

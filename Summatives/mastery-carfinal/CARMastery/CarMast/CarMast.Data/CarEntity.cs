using CarMast.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMast.Data
{
    public class CarEntity : DbContext
    {
        public CarEntity()
            : base("CarMaster")
        {
        }

        public DbSet<User> Userss { get; set; }
        public DbSet<Role> Roless { get; set; }
        public DbSet<Contact> Contacts { get; set; }//
        public DbSet<ExteriorColor> ExteriorColors { get; set; }//
        public DbSet<InteriorColor> InteriorColors { get; set; }//
        public DbSet<Purchase> Purchases { get; set; }//
        public DbSet<PurchaseType> PurchaseTypes { get; set; }//
        public DbSet<Special> Specials { get; set; }//
        public DbSet<State> States { get; set; }//
        public DbSet<Vehicle> Vehicles { get; set; }//
        public DbSet<BodyStyle> BodyStyles { get; set; }//
        public DbSet<Make> Makes { get; set; }//
        public DbSet<Model> Models { get; set; }//
        public DbSet<Transmission> Transmissions { get; set; }//
        public DbSet<VehicleType> VehicleTypes { get; set; }//
    }
}

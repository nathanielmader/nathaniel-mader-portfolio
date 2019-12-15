using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLib.Models
{
    public class DvdLibEntities : DbContext
    {
        public DvdLibEntities()
            //name of connection string
            : base("DefaultConnection")
        {
        }
        //register models with dbcontext class
        public DbSet<Dvd> Dvds { get; set; }
    }
}

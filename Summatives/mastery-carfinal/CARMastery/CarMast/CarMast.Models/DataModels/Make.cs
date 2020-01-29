using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMast.Models.DataModels
{
    public class Make
    {
        public int MakeId { get; set; }
        public string MakeDescription { get; set; }
        public DateTime DateCreated { get; set; }
        //public int UserId { get; set; }

        //public virtual User User { get; set; }
    }
}

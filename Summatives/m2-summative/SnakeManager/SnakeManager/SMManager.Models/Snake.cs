using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMManager.Models
{
    public class Snake
    {
        public int ID { get; set; }
        public SnakeFamily Family { get; set; }
        public string CommonSpeciesName { get; set; }
        public decimal LengthInCentimeters { get; set; }
        public bool Venomous { get; set; }
    }
}

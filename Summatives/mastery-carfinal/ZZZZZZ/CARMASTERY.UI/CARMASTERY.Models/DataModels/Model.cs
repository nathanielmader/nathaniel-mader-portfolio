using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARMASTERY.Models.DataModels
{
    public class Model
    {
        public int ModelId { get; set; }
        public string ModelDescription { get; set; }
        //public DateTime DateAdded { get; set; }
        public int MakeId { get; set; }
        //public DateTime? DateModified { get; set; }

        public virtual Make Make { get; set; }
    }
}

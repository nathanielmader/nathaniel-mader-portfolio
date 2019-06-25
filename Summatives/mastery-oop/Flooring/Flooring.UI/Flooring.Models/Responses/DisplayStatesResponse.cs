using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Responses
{
    public class DisplayStatesResponse : Response
    {
        public List<Taxes> States { get; set; }
    }
}

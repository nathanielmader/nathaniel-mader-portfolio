using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMManager.Controllers;

namespace SManager
{
    public class Program
    {
        static void Main(string[] args)
        {
            SMController go = new SMController();
            go.Run();
        }
    }
}

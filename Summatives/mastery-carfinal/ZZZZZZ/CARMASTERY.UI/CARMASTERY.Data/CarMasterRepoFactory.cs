using CARMASTERY.Data.Interface;
using CARMASTERY.Data.Repos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARMASTERY.Data
{
    public class CarMasterRepoFactory
    {
        public static ICarMasteryRepo Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "QA":
                    return new MockRepo();
                case "PROD":
                    return new EFRepo();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}

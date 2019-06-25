using Flooring.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL
{
    public static class ManagerFactory
    {
        public static Manager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new Manager(new OrderTestRepository(), new ProductTestRepository(), new StateTaxTestRepository());
                case "Prod":
                    return new Manager(new OrderFileRepository(@"F:\REPO\Flooring\Flooring.UI\TestData\"), new ProductFileRepository(), new StateFileRepository());//@"\\Mac\Home\Desktop\SGFlooring\Flooring.UI\ProdData"
                default:
                    throw new Exception("Error. Contact IT.");
            }
        }
    }
}

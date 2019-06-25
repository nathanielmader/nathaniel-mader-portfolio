using Flooring.Models;
using Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class StateTaxTestRepository : IStateRepository
    {
        private static List<Taxes> _stateList = new List<Taxes>()
        {
            new Taxes
            {
                StateAbbreviation = "OH",
                StateName = "Ohio",
                TaxRate = 6.25M
            },
            new Taxes
            {
                StateAbbreviation = "PA",
                StateName = "Pennsylvania",
                TaxRate = 6.75M
            },
            new Taxes
            {
                StateAbbreviation = "MI",
                StateName = "Michigan",
                TaxRate = 5.75M
            },
            new Taxes
            {
                StateAbbreviation = "IN",
                StateName = "Indiana",
                TaxRate = 6.00M
            }
        };
        public List<Taxes> LoadStates()
        {
            List<Taxes> stateList = new List<Taxes>();

            stateList = _stateList;

            return stateList;
        }
    }
}

using Flooring.Models;
using Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class StateFileRepository : IStateRepository
    {
        private string _filePath = @".\Taxes.txt";

        public List<Taxes> LoadStates()
        {
            string file = _filePath;

            List<Taxes> States = new List<Taxes>();

            using (StreamReader sr = new StreamReader(file))
            {
                sr.ReadLine();
                string line;

                while((line = sr.ReadLine()) != null)
                {
                    Taxes newState = new Taxes();

                    string[] columns = line.Split(',');

                    newState.StateAbbreviation = columns[0];
                    newState.StateName = columns[1];
                    newState.TaxRate = decimal.Parse(columns[2]);

                    States.Add(newState);
                }
            }
            return States;
        }
    }
}

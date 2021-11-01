using SOLID_Principles_LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principles_LIB.Interfaces
{
    public interface IMain_Loop
    {
        public void ExecuteDayPassedSimulation(IList<Item> Items);
        public void ExecuteDayPassedSimulationTroughInstance(IList<Item> Items);
    }
}

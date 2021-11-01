using SOLID_Principles_LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principles_LIB.Abstractions
{
    public abstract class ABSTRMain_Loop
    {
        public virtual void ExecuteDayPassedSimulation(IList<Item> Items)
        { 
        }

        public virtual void ExecuteDayPassedSimulationTroughInstance(IList<Item> Items)
        {  
        }

    }
}

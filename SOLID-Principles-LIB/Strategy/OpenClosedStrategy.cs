using SOLID_Principles_LIB.Interfaces;
using SOLID_Principles_LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principles_LIB.Strategy
{
    public class OpenClosedStrategy
    {
        private IMain_Loop _strategy;

        public OpenClosedStrategy()
        { }

        public OpenClosedStrategy(IMain_Loop strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IMain_Loop strategy)
        {
            this._strategy = strategy;
        }

        public void ExecuteDayPassed(IList<Item> Items)
        {
            this._strategy.ExecuteDayPassedSimulationTroughInstance(Items);
        }
    }
}

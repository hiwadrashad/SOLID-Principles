using Microsoft.Extensions.DependencyInjection;
using SOLID_Principles_LIB.Abstractions;
using SOLID_Principles_LIB.Dependency_Injection;
using SOLID_Principles_LIB.Interfaces;
using SOLID_Principles_LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principles_LIB.Functions
{
    public class Main_Loop : ABSTRMain_Loop, IMain_Loop
    {
        private readonly INon_Edge_Cases _nonedgecaseservice;
        private readonly IBack_Stage_Pass _backstagepassservice;
        private readonly IBelow_Zero_Days _belowzerodays;

        public Main_Loop(INon_Edge_Cases nonedgecasesservice, IBack_Stage_Pass backstagepassservice, IBelow_Zero_Days belowzerodays)
        {
            this._nonedgecaseservice = nonedgecasesservice;
            this._backstagepassservice = backstagepassservice;
            this._belowzerodays = belowzerodays;
        }
        
        public new static void ExecuteDayPassedSimulation(IList<Item> Items)
        {
            
            var host = Startup.CreateHostBuilder(new string[0]).Build();
            for (var i = 0; i < Items.Count; i++)
            {
                if (!host.Services.GetRequiredService<Main_Loop>()._nonedgecaseservice.NonEdgeCasesAboveZeroQuality(Items, i))
                {

                    host.Services.GetRequiredService<Main_Loop>()._backstagepassservice.BackstagePassAboveZeroDaysSell(Items, i);
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                host.Services.GetRequiredService<Main_Loop>()._belowzerodays.BelowZeroDaysToSell(Items, i);

            }
        }

        public new void ExecuteDayPassedSimulationTroughInstance(IList<Item> Items)
        {

            var host = Startup.CreateHostBuilder(new string[0]).Build();
            for (var i = 0; i < Items.Count; i++)
            {
                if (!host.Services.GetRequiredService<Main_Loop>()._nonedgecaseservice.NonEdgeCasesAboveZeroQuality(Items, i))
                {

                    host.Services.GetRequiredService<Main_Loop>()._backstagepassservice.BackstagePassAboveZeroDaysSell(Items, i);
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                host.Services.GetRequiredService<Main_Loop>()._belowzerodays.BelowZeroDaysToSell(Items, i);

            }
        }

    }
}

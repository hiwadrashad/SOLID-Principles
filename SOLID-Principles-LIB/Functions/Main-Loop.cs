using Microsoft.Extensions.DependencyInjection;
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
    public class Main_Loop
    {
        private readonly INon_Edge_Cases _nonedgecaseservice;
        private readonly IBack_Stage_Pass _backstagepassservice;

        public Main_Loop(Interfaces.INon_Edge_Cases nonedgecasesservice, Interfaces.IBack_Stage_Pass backstagepassservice)
        {
            this._nonedgecaseservice = nonedgecasesservice;
            this._backstagepassservice = backstagepassservice;
        }
  
        public static void ExecuteDayPassedSimulation(IList<Item> Items)
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

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}

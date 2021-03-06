using Microsoft.Extensions.DependencyInjection;
using SOLID_Principles_LIB.Functions;
using SOLID_Principles_LIB.Interfaces;
using SOLID_Principles_LIB.Singletons;
using SOLID_Principles_LIB.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID_Principles_Frontend
{
    class Program
    {
        private static INon_Edge_Cases _nonedgecasesservice;
        private static IBack_Stage_Pass _backstagepassservice;
        private static IBelow_Zero_Days _belowzerodays;

        public Program(INon_Edge_Cases nonedgecasesservice, IBack_Stage_Pass backstagepassservice, IBelow_Zero_Days belowzerodays)
        {
            _nonedgecasesservice = nonedgecasesservice;
            _backstagepassservice = backstagepassservice;
            _belowzerodays = belowzerodays;
        }
        static void Main(string[] args)
        {

            var Database = ItemsSingleton.GetInstance();

            int index = 0;

            Console.WriteLine(@"  _________________  .____    .___________    __________        .__              .__       .__                 ");
            Console.WriteLine(@" /   _____/\_____  \ |    |   |   \______ \   \______   \_______|__| ____   ____ |__|_____ |  |   ____   ______");
            Console.WriteLine(@" \_____  \  /   |   \|    |   |   ||    |  \   |     ___/\_  __ \  |/    \_/ ___\|  \____ \|  | _/ __ \ /  ___/");
            Console.WriteLine(@" /        \/    |    \    |___|   ||    `   \  |    |     |  | \/  |   |  \  \___|  |  |_> >  |_\  ___/ \___ \ ");
            Console.WriteLine(@"/_______  /\_______  /_______ \___/_______  /  |____|     |__|  |__|___|  /\___  >__|   __/|____/\___  >____  >");
            Console.WriteLine(@"        \/         \/        \/           \/                            \/     \/   |__|             \/     \/ ");
            Console.WriteLine("");

            while (0 == 0)
            {
                if (!(index == 0))
                {
                    OpenClosedStrategy STRATEGY = new OpenClosedStrategy();
                    STRATEGY.SetStrategy(new Adjusted_Conjured_Item_Main_Loop(_nonedgecasesservice, _backstagepassservice, _belowzerodays));
                    STRATEGY.ExecuteDayPassed(Database.GetItems());
                }
                if (Database.GetItems().Where(a => a.Name == "+5 Dexterity Vest").Count() != 0)
                {
                    Console.WriteLine("===========================================================================");
                    Console.WriteLine(" Name : " + Database.GetItems().Where(a => a.Name == "+5 Dexterity Vest").FirstOrDefault().Name);
                    Console.WriteLine(" Sell in given days : " + Database.GetItems().Where(a => a.Name == "+5 Dexterity Vest").FirstOrDefault().SellIn);
                    Console.WriteLine(" Quality : " + Database.GetItems().Where(a => a.Name == "+5 Dexterity Vest").FirstOrDefault().Quality);
                    Console.WriteLine("");
                }
                if (Database.GetItems().Where(a => a.Name == "Aged Brie").Count() != 0)
                {
                    Console.WriteLine("===========================================================================");
                    Console.WriteLine(" Name : " + Database.GetItems().Where(a => a.Name == "Aged Brie").FirstOrDefault().Name);
                    Console.WriteLine(" Sell in given days : " + Database.GetItems().Where(a => a.Name == "Aged Brie").FirstOrDefault().SellIn);
                    Console.WriteLine(" Quality : " + Database.GetItems().Where(a => a.Name == "Aged Brie").FirstOrDefault().Quality);
                    Console.WriteLine("");
                }
                if (Database.GetItems().Where(a => a.Name == "Elixir of the Mongoose").Count() != 0)
                {
                    Console.WriteLine("===========================================================================");
                    Console.WriteLine(" Name : " + Database.GetItems().Where(a => a.Name == "Elixir of the Mongoose").FirstOrDefault().Name);
                    Console.WriteLine(" Sell in given days : " + Database.GetItems().Where(a => a.Name == "Elixir of the Mongoose").FirstOrDefault().SellIn);
                    Console.WriteLine(" Quality : " + Database.GetItems().Where(a => a.Name == "Elixir of the Mongoose").FirstOrDefault().Quality);
                    Console.WriteLine("");
                }
                if (Database.GetItems().Where(a => a.Name == "Sulfuras, Hand of Ragnaros").Count() != 0)
                {
                    Console.WriteLine("===========================================================================");
                    Console.WriteLine(" Name : " + Database.GetItems().Where(a => a.Name == "Sulfuras, Hand of Ragnaros").FirstOrDefault().Name);
                    Console.WriteLine(" Sell in given days : " + Database.GetItems().Where(a => a.Name == "Sulfuras, Hand of Ragnaros").FirstOrDefault().SellIn);
                    Console.WriteLine(" Quality : " + Database.GetItems().Where(a => a.Name == "Sulfuras, Hand of Ragnaros").FirstOrDefault().Quality);
                    Console.WriteLine("");
                }
                if (Database.GetItems().Where(a => a.Name == "Backstage passes to a TAFKAL80ETC concert").Count() != 0)
                {
                    Console.WriteLine("===========================================================================");
                    Console.WriteLine(" Name : " + Database.GetItems().Where(a => a.Name == "Backstage passes to a TAFKAL80ETC concert").FirstOrDefault().Name);
                    Console.WriteLine(" Sell in given days : " + Database.GetItems().Where(a => a.Name == "Backstage passes to a TAFKAL80ETC concert").FirstOrDefault().SellIn);
                    Console.WriteLine(" Quality : " + Database.GetItems().Where(a => a.Name == "Backstage passes to a TAFKAL80ETC concert").FirstOrDefault().Quality);
                    Console.WriteLine("");
                }
                if (Database.GetItems().Where(a => a.Name == "Conjured Mana Cake").Count() != 0)
                {
                    Console.WriteLine("===========================================================================");
                    Console.WriteLine(" Name : " + Database.GetItems().Where(a => a.Name == "Conjured Mana Cake").FirstOrDefault().Name);
                    Console.WriteLine(" Sell in given days : " + Database.GetItems().Where(a => a.Name == "Conjured Mana Cake").FirstOrDefault().SellIn);
                    Console.WriteLine(" Quality : " + Database.GetItems().Where(a => a.Name == "Conjured Mana Cake").FirstOrDefault().Quality);
                    Console.WriteLine("");
                }
                var input = System.Console.ReadLine();
                if (input == "Exit" || input == "exit")
                {
                    break;
                }
                if (input.Contains("Buy") || input.Contains("buy"))
                {
                    Database.RemoveItem(input);
                }
                index = index + 1;
            }

        }

    }
 
}

using SOLID_Principles_LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SOLID_Principles_LIB.Extension_Methods;

namespace SOLID_Principles_Test.Main_Tests
{
    public class Post_Refactoring_Tests
    {

        public static IList<Item> _database = SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().GetItems();
        [Fact (Skip = "Not needed")]

        public void ITEM_DECREASES_IN_QUALITY()
        {
            var itemqualitycount1 = _database.Where(a => a.Name == "+5 Dexterity Vest").FirstOrDefault().Quality;
            var itempre1 = _database.Where(a => a.Name == "+5 Dexterity Vest").FirstOrDefault();
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ReplaceItem(itempre1);
            SOLID_Principles_LIB.Functions.Main_Loop.ExecuteDayPassedSimulation(_database);
            var itempost1 = _database.Where(a => a.Name == "+5 Dexterity Vest").FirstOrDefault();
            Assert.Equal(1, itemqualitycount1 - itempost1.Quality);
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ResetData();

            var itemqualitycount2 = _database.Where(a => a.Name == "Elixir of the Mongoose").FirstOrDefault().Quality;
            var itempre2 = _database.Where(a => a.Name == "Elixir of the Mongoose").FirstOrDefault();
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ReplaceItem(itempre2);
            SOLID_Principles_LIB.Functions.Main_Loop.ExecuteDayPassedSimulation(_database);
            var itempost2 = _database.Where(a => a.Name == "Elixir of the Mongoose").FirstOrDefault();
            Assert.Equal(1, itemqualitycount2 - itempost2.Quality);
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ResetData();

            var itemqualitycount3 = _database.Where(a => a.Name == "Conjured Mana Cake").FirstOrDefault().Quality;
            var itempre3 = _database.Where(a => a.Name == "Conjured Mana Cake").FirstOrDefault();
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ReplaceItem(itempre3);
            SOLID_Principles_LIB.Functions.Main_Loop.ExecuteDayPassedSimulation(_database);
            var itempost3 = _database.Where(a => a.Name == "Conjured Mana Cake").FirstOrDefault();
            Assert.Equal(1, itemqualitycount3 - itempost3.Quality);
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ResetData();
        }

        [Fact(Skip = "Not needed")]
        public void PASS_DATE_DEGRADES_ITEM_TWICE_RATE()
        {

            var itemqualitycount1 = _database.Where(a => a.Name == "+5 Dexterity Vest").FirstOrDefault().Quality;
            var itempre1 = _database.Where(a => a.Name == "+5 Dexterity Vest").FirstOrDefault();
            itempre1.SellIn = 0;
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ReplaceItem(itempre1);
            SOLID_Principles_LIB.Functions.Main_Loop.ExecuteDayPassedSimulation(_database);
            var itempost1 = _database.Where(a => a.Name == "+5 Dexterity Vest").FirstOrDefault();
            Assert.Equal(2, itemqualitycount1 - itempost1.Quality);
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ResetData();

            var itemqualitycount2 = _database.Where(a => a.Name == "Elixir of the Mongoose").FirstOrDefault().Quality;
            var itempre2 = _database.Where(a => a.Name == "Elixir of the Mongoose").FirstOrDefault();
            itempre2.SellIn = 0;
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ReplaceItem(itempre2);
            SOLID_Principles_LIB.Functions.Main_Loop.ExecuteDayPassedSimulation(_database);
            var itempost2 = _database.Where(a => a.Name == "Elixir of the Mongoose").FirstOrDefault();
            Assert.Equal(2, itemqualitycount2 - itempost2.Quality);
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ResetData();

            var itemqualitycount3 = _database.Where(a => a.Name == "Conjured Mana Cake").FirstOrDefault().Quality;
            var itempre3 = _database.Where(a => a.Name == "Conjured Mana Cake").FirstOrDefault();
            itempre3.SellIn = 0;
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ReplaceItem(itempre3);
            SOLID_Principles_LIB.Functions.Main_Loop.ExecuteDayPassedSimulation(_database);
            var itempost3 = _database.Where(a => a.Name == "Conjured Mana Cake").FirstOrDefault();
            Assert.Equal(2, itemqualitycount3 - itempost3.Quality);
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ResetData();
        }

        [Fact(Skip = "Not needed")]
        public void QUALITY_NEVER_NEGATIVE()
        {
            var itempre1 = _database.Where(a => a.Name == "+5 Dexterity Vest").FirstOrDefault();
            itempre1.Quality = 0;
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ReplaceItem(itempre1);
            SOLID_Principles_LIB.Functions.Main_Loop.ExecuteDayPassedSimulation(_database);
            var itempost1 = _database.Where(a => a.Name == "+5 Dexterity Vest").FirstOrDefault();
            Assert.True(itempost1.Quality == 0);
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ResetData();

            var itempre2 = _database.Where(a => a.Name == "Elixir of the Mongoose").FirstOrDefault();
            itempre2.Quality = 0;
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ReplaceItem(itempre2);
            SOLID_Principles_LIB.Functions.Main_Loop.ExecuteDayPassedSimulation(_database);
            var itempost2 = _database.Where(a => a.Name == "Elixir of the Mongoose").FirstOrDefault();
            Assert.True(itempost2.Quality == 0);
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ResetData();

            var itempre3 = _database.Where(a => a.Name == "Backstage passes to a TAFKAL80ETC concert").FirstOrDefault();
            itempre3.Quality = 0;
            itempre3.SellIn = 0;
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ReplaceItem(itempre3);
            SOLID_Principles_LIB.Functions.Main_Loop.ExecuteDayPassedSimulation(_database);
            var itempost3 = _database.Where(a => a.Name == "Backstage passes to a TAFKAL80ETC concert").FirstOrDefault();
            Assert.True(itempost3.Quality == 0);
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ResetData();

            var itempre4 = _database.Where(a => a.Name == "Conjured Mana Cake").FirstOrDefault();
            itempre4.Quality = 0;
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ReplaceItem(itempre4);
            SOLID_Principles_LIB.Functions.Main_Loop.ExecuteDayPassedSimulation(_database);
            var itempost4 = _database.Where(a => a.Name == "Conjured Mana Cake").FirstOrDefault();
            Assert.True(itempost4.Quality == 0);
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ResetData();
        }

        [Fact(Skip = "Not needed")]
        public void AGED_BRIE_QUALITY_INCREASES()
        {
            var itempre4 = _database.Where(a => a.Name == "Aged Brie").FirstOrDefault();
            var itemprequality4 = itempre4.Quality;
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ReplaceItem(itempre4);
            SOLID_Principles_LIB.Functions.Main_Loop.ExecuteDayPassedSimulation(_database);
            var itempost4 = _database.Where(a => a.Name == "Aged Brie").FirstOrDefault();
            Assert.True(itempost4.Quality > itemprequality4);
            SOLID_Principles_LIB.Singletons.ItemsSingleton.GetInstance().ResetData();
        }
    }
}

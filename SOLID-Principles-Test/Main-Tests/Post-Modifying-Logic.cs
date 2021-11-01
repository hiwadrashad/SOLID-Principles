using SOLID_Principles_LIB.Functions;
using SOLID_Principles_LIB.Models;
using SOLID_Principles_LIB.Singletons;
using SOLID_Principles_LIB.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SOLID_Principles_Test.Main_Tests
{
    public class Post_Modifying_Logic
    {

        public IList<Item> database;

        public Post_Modifying_Logic()
        {
            database = new List<Item>()
                {
                    new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                    new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                    new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                    new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                    new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                    new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                };
        }

        [Theory]
        [InlineData("buy +5 Dexterity Vest")]
        [InlineData("Aged Brie")]
        [InlineData("Elixir of the Mongoose")]
        [InlineData("Backstage passes to a TAFKAL80ETC concert")]
        [InlineData("Conjured Mana Cake")]

        public void BUY_ITEMS_REMOVES_FROM_SHOP_STOCK_DEXTERITY_VEST(string input)
        {
            ItemsSingleton.GetInstance().RemoveItem(input);
            bool any = ItemsSingleton.GetInstance().GetItems().Where(a => a.Name == input).Any();
            ItemsSingleton.GetInstance().ResetData();
            Assert.False(any);
        }
        [Fact]
        public void BUY_SULFURAS_DOESNT_REMOVE_STOCK()
        {
            ItemsSingleton.GetInstance().RemoveItem("Sulfuras, Hand of Ragnaros");
            bool any = ItemsSingleton.GetInstance().GetItems().Where(a => a.Name == "Sulfuras, Hand of Ragnaros").Any();
            ItemsSingleton.GetInstance().ResetData();
            Assert.True(any);
        }

        [Theory]
        [InlineData("+5 Dexterity Vest")]
        [InlineData("Elixir of the Mongoose")]

        public void ITEM_DECREASES_IN_QUALITY(string input)
        {
            var itemqualitycount1 = database.Where(a => a.Name == input).FirstOrDefault().Quality;
            OpenClosedStrategy STRATEGY = new OpenClosedStrategy();
            Sub_Functions DIReplacement = new Sub_Functions();
            STRATEGY.SetStrategy(new Adjusted_Conjured_Item_Main_Loop(DIReplacement, DIReplacement, DIReplacement));
            STRATEGY.ExecuteDayPassed(database);
            var itempost1 = database.Where(a => a.Name == input).FirstOrDefault();
            Assert.Equal(1, itemqualitycount1 - itempost1.Quality);
        }

        [Theory]
        [InlineData("+5 Dexterity Vest")]
        [InlineData("Elixir of the Mongoose")]
        public void PASS_DATE_DEGRADES_ITEM_TWICE_RATE(string input)
        {
            var itemqualitycount1 = database.Where(a => a.Name == input).FirstOrDefault().Quality;
            database.Where(a => a.Name == input).FirstOrDefault().SellIn = 0;
            OpenClosedStrategy STRATEGY = new OpenClosedStrategy();
            Sub_Functions DIReplacement = new Sub_Functions();
            STRATEGY.SetStrategy(new Adjusted_Conjured_Item_Main_Loop(DIReplacement, DIReplacement, DIReplacement));
            STRATEGY.ExecuteDayPassed(database);
            var itempost1 = database.Where(a => a.Name == input).FirstOrDefault();
            Assert.Equal(2, itemqualitycount1 - itempost1.Quality);
        }


        [Theory]
        [InlineData("+5 Dexterity Vest")]
        [InlineData("Elixir of the Mongoose")]
        [InlineData("Conjured Mana Cake")]
        public void QUALITY_NEVER_NEGATIVE(string input)
        {
            database.Where(a => a.Name == input).FirstOrDefault().Quality = 0;
            OpenClosedStrategy STRATEGY = new OpenClosedStrategy();
            Sub_Functions DIReplacement = new Sub_Functions();
            STRATEGY.SetStrategy(new Adjusted_Conjured_Item_Main_Loop(DIReplacement, DIReplacement, DIReplacement));
            STRATEGY.ExecuteDayPassed(database);
            Assert.True(database.Where(a => a.Name == input).FirstOrDefault().Quality == 0);
        }


        [Fact]
        public void QUALITY_NEVER_NEGATIVE_BACKSTAGE_PASS()
        {
            database.Where(a => a.Name == "Backstage passes to a TAFKAL80ETC concert").FirstOrDefault().Quality = 0;
            database.Where(a => a.Name == "Backstage passes to a TAFKAL80ETC concert").FirstOrDefault().SellIn = 0;
            OpenClosedStrategy STRATEGY = new OpenClosedStrategy();
            Sub_Functions DIReplacement = new Sub_Functions();
            STRATEGY.SetStrategy(new Adjusted_Conjured_Item_Main_Loop(DIReplacement, DIReplacement, DIReplacement));
            STRATEGY.ExecuteDayPassed(database);
            Assert.True(database.Where(a => a.Name == "Backstage passes to a TAFKAL80ETC concert").FirstOrDefault().Quality == 0);
        }


        [Fact]
        public void AGED_BRIE_QUALITY_INCREASES()
        {
            var itemprequality = database.Where(a => a.Name == "Aged Brie").FirstOrDefault().Quality;
            OpenClosedStrategy STRATEGY = new OpenClosedStrategy();
            Sub_Functions DIReplacement = new Sub_Functions();
            STRATEGY.SetStrategy(new Adjusted_Conjured_Item_Main_Loop(DIReplacement, DIReplacement, DIReplacement));
            STRATEGY.ExecuteDayPassed(database);
            var itempost = database.Where(a => a.Name == "Aged Brie").FirstOrDefault();
            Assert.True(itempost.Quality > itemprequality);
        }

        [Theory]
        [InlineData("Aged Brie")]
        [InlineData("Backstage passes to a TAFKAL80ETC concert")]
        public void QUALITY_OF_ITEM_NEVER_ABOVE_50(string input)
        {
            database.Where(a => a.Name == input).FirstOrDefault().Quality = 50;
            OpenClosedStrategy STRATEGY = new OpenClosedStrategy();
            Sub_Functions DIReplacement = new Sub_Functions();
            STRATEGY.SetStrategy(new Adjusted_Conjured_Item_Main_Loop(DIReplacement, DIReplacement, DIReplacement));
            STRATEGY.ExecuteDayPassed(database);
            var itempost = database.Where(a => a.Name == input).FirstOrDefault();
            Assert.True(itempost.Quality == 50);
        }


        [Fact]
        public void SULFARAS_DOESNT_DECREASE_QUALITY()
        {
            OpenClosedStrategy STRATEGY = new OpenClosedStrategy();
            Sub_Functions DIReplacement = new Sub_Functions();
            STRATEGY.SetStrategy(new Adjusted_Conjured_Item_Main_Loop(DIReplacement, DIReplacement, DIReplacement));
            STRATEGY.ExecuteDayPassed(database);
            var itempost = database.Where(a => a.Name == "Sulfuras, Hand of Ragnaros").FirstOrDefault();
            Assert.True(itempost.Quality == 80);
        }


        [Fact]
        public void BACKSTAGE_PASS_DIVERGENT_QUALITY_RATE()
        {
            var previousquality = database.Where(a => a.Name == "Backstage passes to a TAFKAL80ETC concert").FirstOrDefault().Quality;
            OpenClosedStrategy STRATEGY = new OpenClosedStrategy();
            Sub_Functions DIReplacement = new Sub_Functions();
            STRATEGY.SetStrategy(new Adjusted_Conjured_Item_Main_Loop(DIReplacement, DIReplacement, DIReplacement));
            STRATEGY.ExecuteDayPassed(database);
            var itempost = database.Where(a => a.Name == "Backstage passes to a TAFKAL80ETC concert").FirstOrDefault();
            Assert.True(itempost.Quality > previousquality);
        }

        [Fact]
        public void CONJURED_ITEMS_REDUCE_IN_QUALITY_TWICE_AS_FAST()
        { 
           var premodpreviousquality = database.Where(a => a.Name == "Conjured Mana Cake").FirstOrDefault().Quality;
            SOLID_Principles_LIB.Functions.Main_Loop.ExecuteDayPassedSimulation(database);
            var premodpostquality = database.Where(a => a.Name == "Conjured Mana Cake").FirstOrDefault().Quality;
            database = new List<Item>()
                {
                    new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                    new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                    new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                    new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                    new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                    new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                };
            var postmodpreviousquality = database.Where(a => a.Name == "Conjured Mana Cake").FirstOrDefault().Quality;
            SOLID_Principles_LIB.Functions.Adjusted_Conjured_Item_Main_Loop.ExecuteDayPassedSimulation(database);
            var postmodpostquality = database.Where(a => a.Name == "Conjured Mana Cake").FirstOrDefault().Quality;

            Assert.True(((premodpreviousquality - premodpostquality) * 2) == (postmodpreviousquality - postmodpostquality));
        }

    }
}

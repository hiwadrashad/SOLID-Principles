using SOLID_Principles_LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID_Principles_LIB.Extension_Methods;

namespace SOLID_Principles_LIB.Singletons
{
    public class ItemsSingleton
    {
        private ItemsSingleton()
        { }

        private static ItemsSingleton _instance;

        private static IList<Item> _items;
        public static ItemsSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ItemsSingleton();
            }
            if (_items == null)
            {
                _items = new List<Item>()
                {
                    new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                    new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                    new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                    new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                    new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                    new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                };
            }
            return _instance;
        }

        public IList<Item> GetItems()
        {
            return _items;
        }

        public void ResetData()
        {
            _items = new List<Item>()
                {
                    new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                    new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                    new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                    new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                    new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                    new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                };
        }

        public void ReplaceItem(Item item)
        {
            _items.Replace<Item>(_items.Where(a => a.Name == item.Name).FirstOrDefault(), item);
        }

        /// <summary>
        /// Sulfarus removed, not needed to get out of stock
        /// </summary>
        public void RemoveItem(string command)
        {
            List<Item> items = new List<Item>();
            if (command.Contains("+5 Dexterity Vest"))
            {
                _items.RemoveAll<Item>(a => a.Name == "+5 Dexterity Vest");
            }
            if (command.Contains("Aged Brie"))
            {
                _items.RemoveAll<Item>(a => a.Name == "Aged Brie");
            }
            if (command.Contains("Elixir of the Mongoose"))
            {
                _items.RemoveAll<Item>(a => a.Name == "Elixir of the Mongoose");
            }
            if (command.Contains("Backstage passes to a TAFKAL80ETC concert"))
            {
                _items.RemoveAll<Item>(a => a.Name == "Backstage passes to a TAFKAL80ETC concert");
            }
            if (command.Contains("Conjured Mana Cake"))
            {
                _items.RemoveAll<Item>(a => a.Name == "Conjured Mana Cake");
            }
        }
    }
}
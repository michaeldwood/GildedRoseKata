using GildedRose.Models;
using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Aged Brie", SellIn = 1, Quality = 1},
                new Item {Name = "Backstage passes", SellIn = -1, Quality = 2},
                new Item {Name = "Backstage passes", SellIn = 9, Quality = 2},
                new Item {Name = "Sulfuras", SellIn = 2, Quality = 2},
                new Item {Name = "Normal Item", SellIn = -1, Quality = 55},
                new Item {Name = "Normal Item", SellIn = 2, Quality = 2},
                new Item {Name = "INVALID ITEM", SellIn = 2, Quality = 2},
                new Item {Name = "Conjured", SellIn = 2, Quality = 2},
                new Item {Name = "Conjured", SellIn = -1, Quality = 5}
            };

            new GildedRose(Items);
            Console.ReadLine();
        }
    }
}

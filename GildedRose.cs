using System;
using System.Collections.Generic;
using GildedRose.Managers;
using GildedRose.Models;

namespace GildedRose
{
    public class GildedRose
    {
        
        public GildedRose(IList<Item> Items)
        {
            var inventory = new InventoryManager(Items);
            var updatedStock = inventory.UpdateInventory();

            for (var j = 0; j < updatedStock.Count; j++)
            {
                Console.WriteLine(updatedStock[j]);
            }
            Console.WriteLine("");
        }
    }
}

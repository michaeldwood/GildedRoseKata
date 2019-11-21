using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Managers
{
    public class StockManager
    {
        // Mock call to backend to check product exists
        public static bool CheckValidItem(string itemName)
        {
            var items = new List<string>()
            {
                "Aged Brie",
                "Backstage passes",
                "Sulfuras",
                "Normal Item",
                "Conjured"
            };
            return items.Contains(itemName);
        }
    }
}

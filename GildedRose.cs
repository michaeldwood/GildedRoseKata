using System.Collections.Generic;
using GildedRose.Models;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;
        
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateInventory()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];
                bool validItem = CheckValidItem(item.Name);
                if (validItem)
                {
                    if (item.Name != "Sulfuras")
                    {
                        item.SellIn--;
                    }
                    Items[i] = UpdateItemQuality(item);
                }
                else
                {
                    var noItemFound = new Item()
                    {
                        Name = "NO SUCH ITEM"
                    };
                    Items[i] = noItemFound;
                }
            }
        }

        private Item UpdateItemQuality(Item item)
        {
            int QualityDegradationScoreMultiplier = item.SellIn < 0 ? 2 : 1;

            switch (item.Name)
            {
                case "Aged Brie":
                    item.Quality = item.Quality+1;
                    break;

                case "Sulfuras":
                    break;

                case "Conjured":
                    item.Quality = item.Quality - (2 * QualityDegradationScoreMultiplier);
                    break;

                case "Backstage passes":
                    if (item.SellIn > 5 && item.SellIn <= 10)
                    {
                        item.Quality = item.Quality + 2;
                    }
                    else if (item.SellIn > 1 && item.SellIn <= 5)
                    {
                        item.Quality = item.Quality + 3;
                    }
                    else if (item.SellIn == 0)
                    {
                        item.Quality = 0;
                    }
                    else
                    {
                        item.Quality = item.Quality - (1 * QualityDegradationScoreMultiplier);
                    }
                    break;

                default: item.Quality = item.Quality - (1 * QualityDegradationScoreMultiplier);
                    break;
            }

            /* Quality of item is never above 50, TODO: consider implimenting constraint in the Model. 
             * However this currently breaks the expected outcome by degrementing the minimum 50 to 48 */
            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
            return item;
        }

        private bool CheckValidItem(string itemName)
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

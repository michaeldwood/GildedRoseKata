using GildedRose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Managers
{
    public class InventoryManager
    {
        IList<Item> _Items;
        public InventoryManager(IList<Item> Items)
        {
            _Items = Items;
        }

        public IList<Item> UpdateInventory()
        {
            for (int i = 0; i < _Items.Count; i++)
            {
                Item item = _Items[i];
                bool validItem = StockManager.CheckValidItem(item.Name);
                if (validItem)
                {
                    if (item.Name != "Sulfuras")
                    {
                        item.SellIn--;
                    }
                    _Items[i] = UpdateItemQuality(item);
                }
                else
                {
                    var noItemFound = new Item()
                    {
                        Name = "NO SUCH ITEM"
                    };
                    _Items[i] = noItemFound;
                }
            }
            return _Items;
        }


        private Item UpdateItemQuality(Item item)
        {

            switch (item.Name)
            {
                case "Aged Brie":
                    item.Quality = item.Quality + 1;
                    break;

                case "Sulfuras":
                    break;

                case "Conjured":
                    item.Quality = item.Quality - (2 * item.DegradationMultiplyer());
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
                        item.Quality = item.Quality - (1 * item.DegradationMultiplyer());
                    }
                    break;

                default:
                    item.Quality = item.Quality - (1 * item.DegradationMultiplyer());
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
    }
}

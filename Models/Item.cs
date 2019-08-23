using System;

namespace GildedRose.Models
{
    public class Item
    {
        private int _quality;

        public string Name { get; set; }
        public int SellIn { get; set; }

        public int Quality {
            get
            {
                return _quality;
            }
            set
            {
                if (value < 0)
                {
                    _quality = 0;
                }
                else
                {
                   _quality = value;
                }
            }
        }

        public override string ToString()
        {
            return Name + " " + SellIn + " " + Quality;
        }  
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitBox_Console
{
    class Corner
    {
        private string id, color;
        private int height, price;

        public Corner(string id, int height, int price, string color)
        {
            this.id = id;
            this.height = height;
            this.price = price;
            this.color = color;
        }
        public int GetPrice
        {
            get { return this.price; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitBox_Console
{
    abstract class Component
    {
        protected int price;
        protected string id;
        protected int width, depth, height;

        public Component(string id, int height, int width, int depth, int price)
        {
            this.id = id;
            this.height = height;
            this.width = width;
            this.depth = depth;
            this.price = price;
        }
        public int GetPrice
        {
            get { return this.price; }
        }
    }
}

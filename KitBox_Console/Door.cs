using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitBox_Console
{
    class Door : Component
    {
        private string color;

        public Door(string id, int height, int width, int depth,
        double price, string color) : base(id, height, width, depth, price)
        {
            this.color = color;
        }
	    public string GetColor
        {
            get { return this.color; }
        }
    }
}

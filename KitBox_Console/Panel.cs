using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitBox_Console
{
    class Panel : Component
    {
        private string orientation, color,name;

        public Panel(string id, int height, int width, int depth,
        double price, string color) : base(id, height, width, depth, price)
        {
            this.color = color;
            if (height == 0)
            {
                this.orientation = "horizontal";
            }
            else if (depth == 0)
            {
                this.orientation = "back";
            }
            else
            {
                this.orientation = "side";
            }
            this.name = "Panel";
        }
        public string GetOrientation
        {
            get { return this.orientation; }
        }
        public string GetColor
        {
            get { return this.color; }
        }
    }
}

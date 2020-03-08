using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitBox_Console
{
    class Traverse : Component
    {
        private string orientation,name;

        public Traverse(string id, int height, int width, int depth,
        double price) : base(id, height, width, depth, price)
        {
            if (id.Contains("TRR"))
            {
                this.orientation = "back";
            }
            else if (id.Contains("TRF"))
            {
                this.orientation = "front";
            }
            else
            {
                this.orientation = "side";
            }
            this.name = "Traverse";
        }

        public string GetOrientation
        {
            get { return this.orientation; }
        }
    }
}

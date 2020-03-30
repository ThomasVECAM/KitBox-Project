using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_5
{
    public class Traverse : Component
    {
        private string orientation, name;

        public Traverse(string id, int height, int width, int depth,
        double price, int quantity) : base(id, height, width, depth, price, quantity)
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

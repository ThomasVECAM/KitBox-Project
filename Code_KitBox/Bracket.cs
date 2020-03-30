using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_5
{
    public class Bracket : Component
    {
        public Bracket(string id, int height, int width, int depth,
        double price, int quantity) : base(id, height, width, depth, price, quantity)
        {
        }
    }

}

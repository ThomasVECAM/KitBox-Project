using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitBox_Console
{
    // Tasseau
    class Bracket : Component
    {
        public Bracket(string id, int height, int width, int depth,
        int price) : base(id, height, width, depth, price){}
    }
}

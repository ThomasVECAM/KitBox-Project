using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitBox_Console
{
    class Furniture
    {
        private string name;
        private List<Box> boxList;
        private List<Corner> cornerList;
        private int length, width;

        public Furniture(string dimensions)
        {
            this.name = name;
            this.length = length;
            this.width = width;
            this.boxList = new List<Box>();
            this.cornerList = new List<Corner>();
        }

        public void AddBox(Box box)
        {
            boxList.Add(box);
        }
        public void Remove(Box box)
        {
            boxList.Remove(box);
        }
        public int GetPrice()
        {
            //to do
            return 0;
        }
    }
}

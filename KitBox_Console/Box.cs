using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitBox_Console
{


    class Box
    {
        private List<Component> componentList;
        private int width,depth,height;

        public Box(int width, int depth,int height)
        {
            componentList = new List<Component>();
            this.width = width;
            this.depth = depth;
            this.height = height;
        }

        public int Name
        {
            get { return height; }
            set { height = value; }
        }

        public void AddComponent(Component component)
        {
            componentList.Add(component);
        }

        public void RemoveComponent(Component component)
        {
            componentList.Remove(component);
        }
        public int GetPrice()
        {
            return 0;
        }
        public int GetHeight
        {
            get { return this.height; }
        }
        public int GetDepth
        {
            get { return this.depth; }
        }
        public int GetWidth
        {
            get { return this.width; }
        }


    }
}
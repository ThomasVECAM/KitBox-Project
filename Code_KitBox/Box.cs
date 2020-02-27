using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_KitBox
{


    class Box
    {
        private List<Component> componentList;
        private int height;

        public Box()
        {
            componentList = new List<Component>();
            height = 0; //by default
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
    }
}
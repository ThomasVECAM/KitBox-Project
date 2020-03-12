using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KitBox_Console
{
    class Box
    {
        private List<Component> componentList;
        private int width,depth,height;

        public Box(int height,int width, int depth)
        {
            componentList = new List<Component>();
            this.height = height;
            this.width = width;
            this.depth = depth;
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
        public double GetPrice()
        {
            double totalPrice = 0;
            foreach (Component component in componentList)
            {
                totalPrice += component.GetPrice;
            }
            return totalPrice;
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
        public void WriteFacture(string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("          Box :" + GetPrice());
            }
            foreach (Component component in componentList)
            {
                component.WriteFacture(path);
            }
        }
    }
}
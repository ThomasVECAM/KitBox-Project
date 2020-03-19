using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_5
{

    abstract class Component
    {
        protected double price;
        protected string id, name;
        protected int width, depth, height;

        public Component(string id, int height, int width, int depth, double price)
        {
            this.id = id;
            this.height = height;
            this.width = width;
            this.depth = depth;
            this.price = price;
        }
        public double GetPrice
        {
            get { return this.price; }
        }
        /*public void WriteFacture(string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("                  (" + id + ") : " + price + " €");
            }
        }
        public string GetName
        {
            get { return this.name; }
        }*/
    }
    
}

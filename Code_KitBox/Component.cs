using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Interface_5
{

    public abstract class Component
    {
        protected double price;
        protected string id, name;
        protected int width, depth, height;
        public int quantity;

        public Component(string id, int height, int width, int depth, double price, int quantity)
        {
            this.id = id;
            this.height = height;
            this.width = width;
            this.depth = depth;
            this.price = price;
            this.quantity = quantity;
        }
        public double GetPrice
        {
            get { return this.price; }
        }

        public int GetWidth
        {
            get { return this.width; }
        }

        public int GetHeight
        {
            get { return this.height; }
        }

        public int GetDepth
        {
            get { return this.depth; }
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
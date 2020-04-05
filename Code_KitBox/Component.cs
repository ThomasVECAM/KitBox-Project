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
        public string GetId
        {
            get { return this.id; }
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

        public void AddToDB(string furnitureNumber,int boxNumber)
        {
            Globals.command.Parameters.AddWithValue("@Component_Number",Globals.componentIndex);
            Globals.command.Parameters.AddWithValue("@ID_Composant",id);
            Globals.command.Parameters.AddWithValue("@ID_Commande", Globals.commandId);
            Globals.command.Parameters.AddWithValue("@Box",boxNumber);
            Globals.command.Parameters.AddWithValue("@Meuble",furnitureNumber);
            Globals.command.ExecuteNonQuery();
            Globals.command.Parameters.Clear();
            Console.WriteLine("component added");
        }
    }
}
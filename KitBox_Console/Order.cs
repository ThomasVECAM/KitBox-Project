using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KitBox_Console
{
    class Order
    {
        private List<Furniture> furnitureList;

        public Order()
        {
            this.furnitureList = new List<Furniture>();
        }

        public void AddFurniture(Furniture furniture)
        {
            furnitureList.Add(furniture);
        }

        public void RemoveFurniture(Furniture furniture)
        {
            furnitureList.Remove(furniture);
        }

        public double GetPrice()
        {
            double totalPrice = 0;
            foreach(Furniture furniture in furnitureList)
            {
                totalPrice += furniture.GetPrice();
            }
            return totalPrice;
        }
        public void WriteFacture(string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("# Facture client");
                foreach (Furniture furniture in furnitureList)
                {
                    furniture.WriteFacture(path);
                }
                sw.WriteLine("\nPrix total :" + GetPrice());

            }
        } 
    }
}
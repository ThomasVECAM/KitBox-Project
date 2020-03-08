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
        private int id;
        private List<Furniture> furnitureList;


        public Order()
        {
            id = 1;
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
                sw.WriteLine("Facture client");
            }
            foreach(Furniture furniture in furnitureList)
            {
                furniture.WriteFacture(path);
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("Prix total :" + GetPrice());
            }

        }
    }
}
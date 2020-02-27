using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_KitBox
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

        public void  RemoveFurniture(Furniture furniture)
        {
            furnitureList.Remove(furniture);
        }

        public void GetPrice()
        {
            //to do
        }
    }
}
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Interface_5
{
    class Order
    {
        private List<Furniture> furnitureList;
        public Order()
        {
            this.furnitureList = new List<Furniture>();
        }
        public void AddFurniture(int width,int depth)
        {
            furnitureList.Add(new Furniture(width, depth));
        }

        public double GetPrice()
        {
            double totalPrice = 0;
            foreach (Furniture furniture in furnitureList)
                totalPrice += furniture.GetPrice();
            return totalPrice;
        }

        public List<Furniture> GetFurnitureList
        {
            get { return this.furnitureList; }
        }
        public bool InStock()
        {
            foreach(Furniture furniture in furnitureList)
            {
                if (!furniture.InStock())
                    return false;
            }
            return true;
        }

        public void AddToDB(string custommerStatus)
        {
            Globals.db = new MySqlConnection("SERVER=db4free.net;PORT=3306;DATABASE=groupe5;UID=groupe5;PWD=4c66dfc7; old guids=true");
            bool connected = false;
            while (!connected)
                try
                {
                    Globals.db.Open();
                    connected = true;
                }
                catch (Exception) { }

            if (custommerStatus == "particular")

                Globals.person.AddToDB();
            else
                Globals.company.AddToDB_2();
            
            Globals.command = new MySqlCommand("INSERT INTO Commande(ID,ID_Client,Validation)" +
                " VALUES(@ID,@ID_Client,0)", Globals.db);
            Globals.command.Parameters.AddWithValue("@ID", Globals.commandId);
            Globals.command.Parameters.AddWithValue("@ID_Client", Globals.customerId);
            Globals.command.ExecuteNonQuery();
            Globals.command.Parameters.Clear();
            
            Globals.MySQLCommandText = 
                "INSERT INTO Composant_Commande(Component_Number,ID_Composant,ID_Commande,Box,Meuble) VALUES ";

            
            Globals.componentIndex = 1;
            int furnitureNumber = 1;
            foreach (Furniture furniture in furnitureList)
            {
                furniture.AddToDB(furnitureNumber.ToString() + "_");
                furnitureNumber++;
            }
            string sqlAddComponent = Globals.MySQLCommandText.Remove(Globals.MySQLCommandText.Length - 1, 1); 
            //remove last caracter to get a correct sql syntax
            Globals.command = new MySqlCommand(sqlAddComponent, Globals.db);
            Globals.command.ExecuteNonQuery();
            Globals.db.Close();
        }
    }
}

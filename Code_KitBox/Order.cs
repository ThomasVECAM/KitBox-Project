using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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

        public void RemoveFurniture(Furniture furniture)
        {
            furnitureList.Remove(furniture);
        } 

        public double GetPrice()
        {
            double totalPrice = 0;
            foreach (Furniture furniture in furnitureList)
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
        public void Duplicate()
        {
            Furniture copy = new Furniture(0,0);
            Furniture.Copy(furnitureList[Globals.furnitureIndex], copy);
            furnitureList.Add(copy);
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
                catch (Exception erro)
                {
                }
            if (custommerStatus == "particular")
            {
                Globals.person.AddToDB();
            }
            else
                Globals.company.AddToDB_2();
          

                //Création du client dans la base de donnée;
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
                furniture.AddToDB(furnitureNumber.ToString());
                furnitureNumber++;
            }
            string sql = Globals.MySQLCommandText.Remove(Globals.MySQLCommandText.Length - 1, 1);
            Console.WriteLine(sql);
            Globals.command = new MySqlCommand(sql, Globals.db);
            Globals.command.ExecuteNonQuery();
            Globals.db.Close();
        }
    }
}

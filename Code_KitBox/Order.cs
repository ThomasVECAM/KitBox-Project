using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.IO;

namespace Interface_5
{
    class Order
    {
        private List<Furniture> furnitureList;
        private Person client;
        private int id;
        public Order(int id)
        {
            this.furnitureList = new List<Furniture>();
            this.id = id;
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
        public Person Client
        {
            get { return this.client; }
            set { this.client = value; }
        }
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
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
                this.client.AddToDB();
            else
                ((Company)this.client).AddToDB();

            Globals.command = new MySqlCommand("INSERT INTO Commande(ID,ID_Client,Prix,Validation)" +
                " VALUES(@ID,@ID_Client,@Prix,0)", Globals.db);
            Globals.command.Parameters.AddWithValue("@ID", this.id);
            Globals.command.Parameters.AddWithValue("@ID_Client", Globals.customerId);
            Globals.command.Parameters.AddWithValue("@Prix", GetPrice().ToString());
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

        public void Bill()
        {
            StreamWriter bill = new StreamWriter(@"..\..\..\Factures\" + this.id + "_" + this.client.name + ".md");
            bill.Write("### Kitbox Project magasin\n---\n");
            bill.Write("||||\n|-|-|-|\n");
            try 
            {
                Company company = ((Company)this.client);
                bill.Write("|**ID Client :** " + company.id + "|**Nom :** " + company.name + "||\n");
                bill.Write("|**Adresse mail :** " + company.email + "|**N° téléphone :** " + company.phone + "||\n");
                bill.Write("|**Adresse :** " + company.adress + "|**Ville :** " + company.city
                    + "|**Code postal :** " + company.postalCode + "|\n");
                bill.Write("|**N° de TVA :** " + company.tvaNumber + "|||\n");
            }
            catch (Exception)
            {
                bill.Write("|**ID Client :** " + this.client.id + "|**Nom :** " + this.client.name + "||\n");
                bill.Write("|**Adresse mail :** " + this.client.email + "|**N° téléphone :** " + this.client.phone + "||\n");
                bill.Write("|**Adresse :** " + this.client.adress + "|**Ville :** " + this.client.city 
                    + "|**Code postal :** " + this.client.postalCode + "|\n");
            }
            bill.Write("# Facture de la commande n° " + this.id + "\n");
            bill.Write("||*Quantity*|*Price (€)*|\n" + "| -|:-:| -:|\n");
            foreach (Furniture furniture in this.furnitureList)
            {
                bill.Write(furniture.Bill());
            }
            bill.Close();
            /*StreamWriter bill = new StreamWriter(@"..\..\..\Factures\" + Globals.commandId + ".txt");
            bill.Write("KitBox Project magasin" + "\n" + "\n");
            bill.Write("Facture de la commande n° " + Globals.commandId + "\n" + "\n");
            bill.Write("Item            " + "Quantité   " + "Prix (€)"+ "\n");
            foreach (Furniture furniture in this.furnitureList)
            {
                bill.Write(furniture.Bill() +"\n");
            }
            bill.Close();*/
        }
    }
}

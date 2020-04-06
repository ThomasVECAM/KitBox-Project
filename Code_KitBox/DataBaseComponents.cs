using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Interface_5
{
    public class DataBaseComponents
    {
        public List<PanelClass> sidePanelList = new List<PanelClass>();
        public List<PanelClass> backPanelList = new List<PanelClass>();
        public List<PanelClass> horizontalPanelList = new List<PanelClass>();
        public List<Bracket> bracketList = new List<Bracket>();
        public List<Door> doorList = new List<Door>();
        public List<Traverse> sideTraverseList = new List<Traverse>();
        public List<Traverse> backTraverseList = new List<Traverse>();
        public List<Traverse> forwardTraverseList = new List<Traverse>();
        public List<Corner> cornerList = new List<Corner>();
        public List<Cup> cupList = new List<Cup>();

        public DataBaseComponents()
        {
            MySqlConnection db = new MySqlConnection("SERVER=db4free.net;PORT=3306;DATABASE=groupe5;UID=groupe5;PWD=4c66dfc7; old guids=true");
            bool connected  = false;
            while(!connected)
            {
                try
                {
                    db.Open();
                    connected = true;
                }
                catch (Exception) { }
            }

            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = "SELECT Ref,Code, Hauteur, Largeur, Profondeur, Prix_Client, Couleur, En_stock FROM `Composants`";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string componentReference = reader["Ref"].ToString();
                
                if (componentReference == "Panneau GD")
                    sidePanelList.Add(new PanelClass(reader["Code"].ToString(), Convert.ToInt32(reader["Hauteur"]),
                        0, Convert.ToInt32(reader["Profondeur"]), Convert.ToDouble(reader["Prix_Client"]), Convert.ToInt32(reader["En_stock"]),
                        reader["Couleur"].ToString()));

                else if(componentReference == "Panneau Ar")
                    backPanelList.Add(new PanelClass(reader["Code"].ToString(), Convert.ToInt32(reader["Hauteur"]),
                        Convert.ToInt32(reader["Largeur"]), 0,
                        Convert.ToDouble(reader["Prix_Client"]), Convert.ToInt32(reader["En_stock"]), reader["Couleur"].ToString()));

                else if(componentReference == "Panneau HB")
                    horizontalPanelList.Add(new PanelClass(reader["Code"].ToString(), 0,
                        Convert.ToInt32(reader["Largeur"]), Convert.ToInt32(reader["Profondeur"]),
                        Convert.ToDouble(reader["Prix_Client"]), Convert.ToInt32(reader["En_stock"]), reader["Couleur"].ToString()));

                else if (componentReference == "Tasseau")
                    bracketList.Add(new Bracket(reader["Code"].ToString(), Convert.ToInt32(reader["Hauteur"]), 0, 0,
                        Convert.ToDouble(reader["Prix_Client"]), Convert.ToInt32(reader["En_stock"])));

                else if(componentReference == "Traverse GD")
                    sideTraverseList.Add(new Traverse(reader["Code"].ToString(), 0, 0, Convert.ToInt32(reader["Profondeur"]),
                        Convert.ToDouble(reader["Prix_Client"]), Convert.ToInt32(reader["En_stock"])));

                else if(componentReference == "Traverse Ar")
                    backTraverseList.Add(new Traverse(reader["Code"].ToString(), 0,
                        Convert.ToInt32(reader["Largeur"]), 0, Convert.ToDouble(reader["Prix_Client"]),
                        Convert.ToInt32(reader["En_stock"])));

                else if(componentReference == "Traverse Av")
                    forwardTraverseList.Add(new Traverse(reader["Code"].ToString(), 0,
                      Convert.ToInt32(reader["Largeur"]), 0, Convert.ToDouble(reader["Prix_Client"]),
                      Convert.ToInt32(reader["En_stock"])));

                else if (componentReference == "Porte ")
                    doorList.Add(new Door(reader["Code"].ToString(), Convert.ToInt32(reader["Hauteur"]),
                        Convert.ToInt32(reader["Largeur"]), 0, Convert.ToDouble(reader["Prix_Client"]),
                        Convert.ToInt32(reader["En_stock"]), reader["Couleur"].ToString()));

                else if(componentReference == "Cornieres" )
                    cornerList.Add(new Corner(reader["Code"].ToString(), Convert.ToInt32(reader["Hauteur"]),
                        Convert.ToDouble(reader["Prix_Client"]), Convert.ToInt32(reader["En_stock"]),
                        reader["Couleur"].ToString()));

                else if(componentReference == "Coupelles")
                    cupList.Add(new Cup(reader["Code"].ToString(), 0, 0, 0,
                        Convert.ToDouble(reader["Prix_Client"]), Convert.ToInt32(reader["En_stock"])));
            }
            db.Close();
        }
    }
}

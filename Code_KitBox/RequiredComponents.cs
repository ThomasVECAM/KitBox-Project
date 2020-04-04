using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Interface_5
{
    public class RequiredComponents
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

        public RequiredComponents()
        {
            MySqlConnection db = new MySqlConnection("SERVER=db4free.net;PORT=3306;DATABASE=groupe5;UID=groupe5;PWD=4c66dfc7; old guids=true");
            bool connected  = false;
            while(!connected)
            try
            {
                db.Open();
                connected = true;
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro" + erro);
            }
            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = "SELECT Ref,Code, Hauteur, Largeur, Profondeur, Prix_Client, Couleur, En_stock FROM `Composants`";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string componentReference = reader["Ref"].ToString();
                
                if (componentReference == "Panneau GD")
                {
                    sidePanelList.Add(new PanelClass(reader["Code"].ToString(), Convert.ToInt32(reader["Hauteur"]),
                        0, Convert.ToInt32(reader["Profondeur"]), Convert.ToDouble(reader["Prix_Client"]), Convert.ToInt32(reader["En_stock"]),
                        reader["Couleur"].ToString()));
                }
                else if(componentReference == "Panneau Ar")
                {
                    backPanelList.Add(new PanelClass(reader["Code"].ToString(), Convert.ToInt32(reader["Hauteur"]),
                        Convert.ToInt32(reader["Largeur"]), 0,
                        Convert.ToDouble(reader["Prix_Client"]), Convert.ToInt32(reader["En_stock"]), reader["Couleur"].ToString()));
                }



                else if(componentReference == "Panneau HB")
                {
                    Console.WriteLine("Panneau added");
                    horizontalPanelList.Add(new PanelClass(reader["Code"].ToString(), 0,
                        Convert.ToInt32(reader["Largeur"]), Convert.ToInt32(reader["Profondeur"]),
                        Convert.ToDouble(reader["Prix_Client"]), Convert.ToInt32(reader["En_stock"]), reader["Couleur"].ToString()));
                }

                else if (componentReference == "Tasseau")
                {
                    bracketList.Add(new Bracket(reader["Code"].ToString(), Convert.ToInt32(reader["Hauteur"]), 0, 0,
                        Convert.ToDouble(reader["Prix_Client"]), Convert.ToInt32(reader["En_stock"])));
                }

                else if(componentReference == "Traverse GD")
                {
                    sideTraverseList.Add(new Traverse(reader["Code"].ToString(), 0, 0, Convert.ToInt32(reader["Profondeur"]),
                        Convert.ToDouble(reader["Prix_Client"]), Convert.ToInt32(reader["En_stock"])));
                }

                else if(componentReference == "Traverse Ar")
                {
                    backTraverseList.Add(new Traverse(reader["Code"].ToString(), 0,
                        Convert.ToInt32(reader["Largeur"]), 0, Convert.ToDouble(reader["Prix_Client"]),
                        Convert.ToInt32(reader["En_stock"])));
                }

                else if(componentReference == "Traverse Av")
                {
                    forwardTraverseList.Add(new Traverse(reader["Code"].ToString(), 0,
                      Convert.ToInt32(reader["Largeur"]), 0, Convert.ToDouble(reader["Prix_Client"]),
                      Convert.ToInt32(reader["En_stock"])));
                }

                else if (componentReference == "Porte ")
                {
                    doorList.Add(new Door(reader["Code"].ToString(), Convert.ToInt32(reader["Hauteur"]),
                        Convert.ToInt32(reader["Largeur"]), 0, Convert.ToDouble(reader["Prix_Client"]),
                        Convert.ToInt32(reader["En_stock"]), reader["Couleur"].ToString()));
                }

                else if(componentReference == "Cornieres" )
                {
                    cornerList.Add(new Corner(reader["Code"].ToString(), Convert.ToInt32(reader["Hauteur"]),
                        Convert.ToDouble(reader["Prix_Client"]), Convert.ToInt32(reader["En_stock"]),
                        reader["Couleur"].ToString()));
                }
                else if(componentReference == "Coupelles")
                {
                    cupList.Add(new Cup(reader["Code"].ToString(), 0, 0, 0,
                        Convert.ToDouble(reader["Prix_Client"]), Convert.ToInt32(reader["En_stock"])));
                }
            }
            db.Close();
        }

        /* public void SearchRequiredComponents()
         {
             //Association to database
             MySqlConnection db = new MySqlConnection("SERVER=db4free.net;PORT=3306;DATABASE=groupe5;UID=groupe5;PWD=4c66dfc7; old guids=true");

             //Ajout des panneaux
             //Panneaux GD
             db.Open();
             MySqlCommand cmd = db.CreateCommand();
             cmd.CommandText = "SELECT Code, Hauteur, Profondeur, Prix_Client, Couleur FROM `Composants` WHERE `Ref`='Panneau GD' AND `Profondeur`=" 
                             + Globals.order.GetFurnitureList[Globals.furnitureIndex].GetDepth;
                              // + " AND `Hauteur`=" + this.height + " AND `Couleur` = '" + this.color + "'";

             MySqlDataReader reader = cmd.ExecuteReader();
             while (reader.Read())
             {
                 sidePanelList.Add(new PanelClass(reader["Code"].ToString(), Convert.ToInt32(reader["Hauteur"]),
                    0, Convert.ToInt32(reader["Profondeur"]), Convert.ToDouble(reader["Prix_Client"]),
                    reader["Couleur"].ToString()));
             }
             db.Close();

             //Panneau arrière
             db.Open();
             MySqlCommand cmd2 = db.CreateCommand();
             cmd2.CommandText = "SELECT Code,Hauteur,Largeur, Prix_Client,Couleur FROM `Composants` WHERE `Ref`='Panneau Ar' AND`Largeur`=" 
                 + Globals.order.GetFurnitureList[Globals.furnitureIndex].GetWidth;
             //  + " AND `Hauteur`=" + this.height + " AND `Couleur` = '" + this.color + "'";

             MySqlDataReader reader2 = cmd2.ExecuteReader();
             while (reader2.Read())
             {
                 backPanelList.Add(new PanelClass(reader2["Code"].ToString(), Convert.ToInt32(reader2["Hauteur"]),
                     Convert.ToInt32(reader2["Largeur"]), 0,
                     Convert.ToDouble(reader2["Prix_Client"]), reader2["Couleur"].ToString()));
             }
             db.Close();

             //Panneau Haut bas
             db.Open();
             MySqlCommand cmd3 = db.CreateCommand();
             cmd3.CommandText = "SELECT Code,Largeur,Profondeur,Prix_Client,Couleur FROM `Composants` WHERE `Ref`='Panneau HB' AND`Largeur`=" 
                 + Globals.order.GetFurnitureList[Globals.furnitureIndex].GetWidth
                 + " AND `Profondeur`=" 
                 + Globals.order.GetFurnitureList[Globals.furnitureIndex].GetDepth;
             //+ " AND `Couleur` = '" + color + "'";

             MySqlDataReader reader3 = cmd3.ExecuteReader();
             while (reader3.Read())
             {
                 horizontalPanelList.Add(new PanelClass(reader3["Code"].ToString(), 0,
                     Convert.ToInt32(reader3["Largeur"]), Convert.ToInt32(reader3["Profondeur"]),
                      Convert.ToDouble(reader3["Prix_Client"]), reader3["Couleur"].ToString()));
             }
             db.Close();

             //Ajout des tasseaux adéquats
             db.Open();
             MySqlCommand cmd4 = db.CreateCommand();
             cmd4.CommandText = "SELECT Code,Hauteur,Prix_Client FROM `Composants` WHERE `Ref`= 'Tasseau'";// AND`Hauteur`=" + height;
             MySqlDataReader reader4 = cmd4.ExecuteReader();
             while (reader4.Read())
             {
                 bracketList.Add(new Bracket(reader4["Code"].ToString(), Convert.ToInt32(reader4["Hauteur"]), 0, 0,
                     Convert.ToDouble(reader4["Prix_Client"])));
             }
             db.Close();


             //Ajout des traverses GD

             db.Open();
             MySqlCommand cmd5 = db.CreateCommand();
             cmd5.CommandText = "SELECT Code,Profondeur,Prix_Client FROM `Composants` WHERE `Ref`= 'Traverse GD' AND`Profondeur`="
                 + Globals.order.GetFurnitureList[Globals.furnitureIndex].GetDepth;

             MySqlDataReader reader5 = cmd5.ExecuteReader();
             if (reader5.Read())
             {
                 sideTraverse = new Traverse(reader5["Code"].ToString(), 0, 0, Convert.ToInt32(reader5["Profondeur"]),
                     Convert.ToDouble(reader5["Prix_Client"]));
             }
             db.Close();

             //Ajout traverse arrière
             db.Open();
             MySqlCommand cmd6 = db.CreateCommand();
             cmd6.CommandText = "SELECT Code,Largeur,Prix_Client FROM `Composants` WHERE `Ref`= 'Traverse Ar' AND`Largeur`="
                 + Globals.order.GetFurnitureList[Globals.furnitureIndex].GetWidth;

             MySqlDataReader reader6 = cmd6.ExecuteReader();
             if (reader6.Read())
             {
                  backTraverse = new Traverse(reader6["Code"].ToString(), 0,
                     Convert.ToInt32(reader6["Largeur"]), 0, Convert.ToDouble(reader6["Prix_Client"]));
             }
             db.Close();

             //Ajout des traverses avant
             db.Open();
             MySqlCommand cmd7 = db.CreateCommand();
             cmd7.CommandText = "SELECT Code,Largeur,Prix_Client FROM `Composants` WHERE `Ref`= 'Traverse Av' AND`Largeur`=" 
                 + Globals.order.GetFurnitureList[Globals.furnitureIndex].GetWidth;

             MySqlDataReader reader7 = cmd7.ExecuteReader();
             if (reader7.Read())
             {
                  forwardTraverse = new Traverse(reader7["Code"].ToString(), 0,
                     Convert.ToInt32(reader7["Largeur"]), 0, Convert.ToDouble(reader7["Prix_Client"]));
             }
             db.Close();



             //Ajout des portes
             db.Open();
             MySqlCommand cmd8 = db.CreateCommand();
             cmd8.CommandText = "SELECT Code,Hauteur,Largeur,Prix_Client FROM `Composants` WHERE `Ref`= 'Traverse Av' AND`Largeur`="
                 + Globals.order.GetFurnitureList[Globals.furnitureIndex].GetWidth;

             MySqlDataReader reader8 = cmd8.ExecuteReader();
             if (reader8.Read())
             {
                 doorList.Add(new Door(reader8["Code"].ToString(), Convert.ToInt32(reader8["Hauteur"]),
                    Convert.ToInt32(reader8["Largeur"]), 0, Convert.ToDouble(reader8["Prix_Client"]),reader8["Couleur"].ToString()));
             }
             db.Close();
         }*/
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace KitBox_Console
{
    class Box
    {
        private List<Component> componentList;
        private int width,depth,height;
        private string color;

        public Box(int height,int width, int depth, string color)
        {
            componentList = new List<Component>();
            this.height = height;
            this.width = width;
            this.depth = depth;
            this.color = color;
        }

        public int Name
        {
            get { return height; }
            set { height = value; }
        }

        public void AddRequiredComponents()
        {
            //Association to database
            MySqlConnection db = new MySqlConnection("SERVER=db4free.net;PORT=3306;DATABASE=groupe5;UID=groupe5;PWD=4c66dfc7; old guids=true");

        //Ajout des panneaux
        //Panneaux GD
            db.Open();
            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = "SELECT Code, Hauteur, Profondeur, Prix_Client, Couleur FROM `Composants` WHERE `Ref`='Panneau GD' AND `Profondeur`=" + this.depth
                              + " AND `Hauteur`=" + this.height + " AND `Couleur` = '" + this.color + "'";
            
            MySqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                 Panel side_panel = new Panel(reader["Code"].ToString(), Convert.ToInt32(reader["Hauteur"]),
                    0, Convert.ToInt32(reader["Profondeur"]), Convert.ToDouble(reader["Prix_Client"]),
                    reader["Couleur"].ToString());
                AddComponent(side_panel);
                AddComponent(side_panel);

            }
            else
            {
                Console.WriteLine("No pannel compatible");
            }
            db.Close();

    //Panneau arrière
            db.Open();
            MySqlCommand cmd2 = db.CreateCommand();
            cmd2.CommandText = "SELECT Code,Hauteur,Largeur, Prix_Client,Couleur FROM `Composants` WHERE `Ref`='Panneau Ar' AND`Largeur`=" + this.width
                                + " AND `Hauteur`=" + this.height + " AND `Couleur` = '" + this.color + "'";
            
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            if(reader2.Read())
            {
                Panel backpanel = new Panel(reader2["Code"].ToString(), Convert.ToInt32(reader2["Hauteur"]),
                    Convert.ToInt32(reader2["Largeur"]),0,
                    Convert.ToDouble(reader2["Prix_Client"]), reader2["Couleur"].ToString());
                AddComponent(backpanel);
            }
            else
            {
                Console.WriteLine("Panneau non compatible");
            }
            db.Close();

        //Panneau Haut bas
            db.Open();
            MySqlCommand cmd3 = db.CreateCommand();
            cmd3.CommandText = "SELECT Code,Largeur,Profondeur,Prix_Client,Couleur FROM `Composants` WHERE `Ref`='Panneau HB' AND`Largeur`=" + width
                + " AND `Profondeur`=" + depth + " AND `Couleur` = '" + color + "'";

            MySqlDataReader reader3 = cmd3.ExecuteReader();
            List<Panel> horizontal_panel_list = new List<Panel>();
            if(reader3.Read())
            {
                Panel horizontal_panel = new Panel(reader3["Code"].ToString(), 0,
                    Convert.ToInt32(reader3["Largeur"]), Convert.ToInt32(reader3["Profondeur"]),
                     Convert.ToDouble(reader3["Prix_Client"]), reader3["Couleur"].ToString());
                AddComponent(horizontal_panel);
                AddComponent(horizontal_panel);
            }
            else
            {
                Console.WriteLine("Panneau non compatible");
            }
            db.Close();

            //Ajout des tasseaux adéquats
            db.Open();
            MySqlCommand cmd4 = db.CreateCommand();
            cmd4.CommandText = "SELECT Code,Hauteur,Prix_Client FROM `Composants` WHERE `Ref`= 'Tasseau' AND`Hauteur`=" + height;
            MySqlDataReader reader4 = cmd4.ExecuteReader();
            if(reader4.Read())
            {
                Bracket bracket = new Bracket(reader4["Code"].ToString(), Convert.ToInt32(reader4["Hauteur"]), 0, 0,
                    Convert.ToDouble(reader4["Prix_Client"]));

                AddComponent(bracket);
                AddComponent(bracket);
                AddComponent(bracket);
                AddComponent(bracket);
            }
            else
            {
                Console.WriteLine("Aucun tasseaux adéquats");
            }
            db.Close();
        //Ajout des traverses GD

            db.Open();
            MySqlCommand cmd5 = db.CreateCommand();
            cmd5.CommandText = "SELECT Code,Profondeur,Prix_Client FROM `Composants` WHERE `Ref`= 'Traverse GD' AND`Profondeur`=" + depth;
            MySqlDataReader reader5 = cmd5.ExecuteReader();
            if(reader5.Read())
            {
                Traverse side_traverse = new Traverse(reader5["Code"].ToString(), 0, 0, Convert.ToInt32(reader5["Profondeur"]),
                    Convert.ToDouble(reader5["Prix_Client"]));
                AddComponent(side_traverse);
                AddComponent(side_traverse);
            }
            db.Close();

        //Ajout traverse arrière
            db.Open();
            MySqlCommand cmd6 = db.CreateCommand();
            cmd6.CommandText = "SELECT Code,Largeur,Prix_Client FROM `Composants` WHERE `Ref`= 'Traverse Ar' AND`Largeur`=" + width;
            MySqlDataReader reader6 = cmd6.ExecuteReader();
            if(reader6.Read())
            {
               Traverse back_traverse = new Traverse(reader6["Code"].ToString(), 0,
                   Convert.ToInt32(reader6["Largeur"]), 0, Convert.ToDouble(reader6["Prix_Client"]));
                AddComponent(back_traverse);
            }
            db.Close();

        //Ajout des traverses avant
            db.Open();
            MySqlCommand cmd7 = db.CreateCommand();
            cmd7.CommandText = "SELECT Code,Largeur,Prix_Client FROM `Composants` WHERE `Ref`= 'Traverse Av' AND`Largeur`=" + width;
            MySqlDataReader reader7 = cmd7.ExecuteReader();
            
            if(reader7.Read())
            {
                Traverse forward_traverse = new Traverse(reader7["Code"].ToString(), 0,
                    Convert.ToInt32(reader7["Largeur"]), 0, Convert.ToDouble(reader7["Prix_Client"]));
                AddComponent(forward_traverse);
            }
            else
            {
                Console.WriteLine("Aucune traverses compatibles");
            }
            db.Close();
        }

        public void AddComponent(Component component)
        {
            componentList.Add(component);
        }
        public void RemoveComponent(Component component)
        {
            componentList.Remove(component);
        }
        public double GetPrice()
        {
            double totalPrice = 0;
            foreach (Component component in componentList)
            {
                totalPrice += component.GetPrice;
            }
            return totalPrice;
        }
        public int GetHeight
        {
            get { return this.height; }
        }
        public int GetDepth
        {
            get { return this.depth; }
        }
        public int GetWidth
        {
            get { return this.width; }
        }
        public string GetColor
        {
            get { return this.color; }
        }
        public void WriteFacture(string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("          Box :" + GetPrice());
            }
            /*foreach (Component component in componentList)
            {
                component.WriteFacture(path);
            }*/
        }
    }
}
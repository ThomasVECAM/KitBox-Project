using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KitBox_Console


{
    class Program
    {
        static void Main(string[] args)
        {
            //Connexion to database
            MySqlConnection db = new MySqlConnection("SERVER=db4free.net;PORT=3306;DATABASE=groupe5;UID=groupe5;PWD=4c66dfc7; old guids=true");
            
            try
            {
                db.Open();
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro" + erro);
            } //db.Open

            //Create a order
            Order order = new Order();

            //Choix dimensions meuble - en fonction des plaques horizontales existantes
            
            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = "SELECT Dimension,Largeur,Profondeur FROM `Composants` WHERE `Ref`='Panneau HB'";
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Tuple<string, int, int>> list = new List<Tuple<string, int, int>>(); //liste où l'on va stocker les composants
            while (reader.Read())
            {
                list.Add(new Tuple<string, int, int>(reader["Dimension"].ToString(),
                    Convert.ToInt32(reader["Largeur"]), Convert.ToInt32(reader["Profondeur"])));
            }
            list = list.Distinct().ToList(); //enlever les panneaux de même taille
            foreach (Tuple<string, int, int> element in list)
            {
                Console.WriteLine(element.Item1);
            }
            db.Close();
            Console.WriteLine("------------------------------------------------------------");

            //Ajouter un meuble à la commande

            Console.WriteLine("Ajout d'un meuble");
            Furniture furniture = new Furniture(list[0].Item2, list[0].Item3);  //pour essayer, on prend le premier élement de 
                                                                         //la liste ci-dessus pour les dimensions du meuble
            order.AddFurniture(furniture);
            furniture.Name = "Meuble 1"; //changement du nom du meuble
            
            Console.WriteLine("Nom du meuble : " + furniture.Name); //test du changement de nom
            Console.WriteLine("------------------------------------------------------------");


            Console.WriteLine("Ajout d'une box à un meuble ici : " + furniture.Name);
            Console.WriteLine("Choix de la hauteur de la box");

            //Création d'une liste avec les hauteurs possibles
            db.Open();
            MySqlCommand cmd2 = db.CreateCommand();
            cmd2.CommandText = "SELECT Hauteur FROM `Composants` WHERE `Ref`='Panneau GD' AND `Profondeur`=" + furniture.GetDepth;
            //N.B. : j'aurais aussi pu faire la recherche sur le panneau arrière

            MySqlDataReader reader2 = cmd2.ExecuteReader();
            List<int> list2 = new List<int>();
            while (reader2.Read())
            {
                list2.Add(Convert.ToInt32(reader2["Hauteur"]));
            }
            list2 = list2.Distinct().ToList(); //enlever les objets qui ont les mêmes hauteur
            foreach (int value in list2)
            {
                Console.WriteLine(value); //impression des différentes hauteurs
            }
            db.Close();

            Box box = new Box(list2[0], furniture.GetWidth, furniture.GetDepth); //création d'une box de hauteur de la liste des hauteurs
            //Console.WriteLine("Ajout de 2 box de hauteur LISTE 0 des hauteurs au meuble");

            furniture.AddBox(box);
            furniture.AddBox(box); //on ajoute deux box, identiques au meuble(utile pour tester la hauteur des cornières)
            Console.WriteLine("-------------------------------------------------------------");

            Console.WriteLine("Ajout des panneaux");
            // Ajout des panneaux 
            //1) Gauche Droite

            Console.WriteLine("        Panneaux GD choix : ");
            db.Open();
            MySqlCommand cmd4 = db.CreateCommand();
            cmd4.CommandText = "SELECT Code,Hauteur,Profondeur,Prix_Client,Couleur FROM `Composants` WHERE `Ref`='Panneau GD' AND `Profondeur`=" + box.GetDepth + " AND `Hauteur`=" + box.GetHeight;

            MySqlDataReader reader4 = cmd4.ExecuteReader();
            List<Panel> side_panel_list = new List<Panel>();
            while (reader4.Read())
            {
                side_panel_list.Add(new Panel(reader4["Code"].ToString(), Convert.ToInt32(reader4["Hauteur"]),
                    0, Convert.ToInt32(reader4["Profondeur"]), Convert.ToDouble(reader4["Prix_Client"]),
                    reader4["Couleur"].ToString()));
            }
            db.Close();
            foreach (Panel panel in side_panel_list)
            {
                Console.WriteLine(panel.GetColor + " : " + panel.GetPrice + " euros");//afficher la couleur du meuble à choisir
            }

            //2) Arrière
            Console.WriteLine("        Panneau Arrière");
            db.Open();
            MySqlCommand cmd5 = db.CreateCommand();
            cmd5.CommandText = "SELECT Code,Hauteur,Largeur,Profondeur,Prix_Client,Couleur FROM `Composants` WHERE `Ref`='Panneau Ar' AND`Largeur`=" + box.GetWidth + " AND `Hauteur`=" + box.GetHeight;

            MySqlDataReader reader5 = cmd5.ExecuteReader();
            List<Panel> back_panel_list = new List<Panel>();
            while (reader5.Read())
            {
                back_panel_list.Add(new Panel(reader5["Code"].ToString(), Convert.ToInt32(reader5["Hauteur"]),
                    Convert.ToInt32(reader5["Largeur"]), Convert.ToInt32(reader5["Profondeur"]),
                    Convert.ToDouble(reader5["Prix_Client"]), reader5["Couleur"].ToString()));
            }
            db.Close();
            foreach (Panel panel in back_panel_list)
            {
                Console.WriteLine(panel.GetColor + " : " + panel.GetPrice + " euros");//afficher la couleur du meuble à choisir
            }

            //3) HAUT BAS

            Console.WriteLine("        Panneaux HB");
            db.Open();
            MySqlCommand cmd6 = db.CreateCommand();
            cmd6.CommandText = "SELECT Code,Hauteur,Largeur,Profondeur,Prix_Client,Couleur FROM `Composants` WHERE `Ref`='Panneau HB' AND`Largeur`=" + box.GetWidth + " AND `Profondeur`=" + box.GetDepth;

            MySqlDataReader reader6 = cmd6.ExecuteReader();
            List<Panel> horizontal_panel_list = new List<Panel>();
            while (reader6.Read())
            {
                horizontal_panel_list.Add(new Panel(reader6["Code"].ToString(), Convert.ToInt32(reader6["Hauteur"]),
                    Convert.ToInt32(reader6["Largeur"]), Convert.ToInt32(reader6["Profondeur"]),
                     Convert.ToDouble(reader6["Prix_Client"]), reader6["Couleur"].ToString()));
            }
            db.Close();
            foreach (Panel panel in horizontal_panel_list)
            {
                Console.WriteLine(panel.GetColor + " : " + panel.GetPrice + " euros");//afficher la couleur du meuble à choisir
            }

            Console.WriteLine("---------------------------------------------");

            //Ajout des tasseaux adéquats
            Console.WriteLine("Ajout tasseau:");
            db.Open();
            MySqlCommand cmd7 = db.CreateCommand();
            cmd7.CommandText = "SELECT Code,Hauteur,Prix_Client FROM `Composants` WHERE `Ref`= 'Tasseau' AND`Hauteur`=" + box.GetHeight;
            MySqlDataReader reader7 = cmd7.ExecuteReader();
            List<Bracket> bracket_list = new List<Bracket>();
            while (reader7.Read())
            {
                bracket_list.Add(new Bracket(reader7["Code"].ToString(), Convert.ToInt32(reader7["Hauteur"]), 0, 0,
                    Convert.ToDouble(reader7["Prix_Client"])));
            }
            db.Close();
            foreach (Bracket bracket in bracket_list)
            {
                Console.WriteLine(bracket.GetPrice + " euros");//afficher la couleur du meuble à choisir
            }


            //Ajout des traverses gauche et droites

            Console.WriteLine("Traverses gauche droites");
            db.Open();
            MySqlCommand cmd8 = db.CreateCommand();
            cmd8.CommandText = "SELECT Code,Profondeur,Prix_Client FROM `Composants` WHERE `Ref`= 'Traverse GD' AND`Profondeur`=" + box.GetDepth;
            MySqlDataReader reader8 = cmd8.ExecuteReader();
            List<Traverse> side_traverse_list = new List<Traverse>();
            while (reader8.Read())
            {
                side_traverse_list.Add(new Traverse(reader8["Code"].ToString(), 0, 0, Convert.ToInt32(reader8["Profondeur"]),
                    Convert.ToDouble(reader8["Prix_Client"])));
            }
            foreach (Traverse traverse in side_traverse_list)
            {
                Console.WriteLine(traverse.GetPrice);
            }
            db.Close();

            //Ajout des traverses arrière
            Console.WriteLine("Traverse arrière");
            db.Open();
            MySqlCommand cmd9 = db.CreateCommand();
            cmd9.CommandText = "SELECT Code,Largeur,Prix_Client FROM `Composants` WHERE `Ref`= 'Traverse Ar' AND`Largeur`=" + box.GetWidth;
            MySqlDataReader reader9 = cmd9.ExecuteReader();
            List<Traverse> back_traverse_list = new List<Traverse>();

            while (reader9.Read())
            {
                back_traverse_list.Add(new Traverse(reader9["Code"].ToString(), 0,
                    Convert.ToInt32(reader9["Largeur"]), 0, Convert.ToDouble(reader9["Prix_Client"])));
            }
            db.Close();
            foreach (Traverse traverse in back_traverse_list)
            {
                Console.WriteLine(traverse.GetPrice);
            }

            //Ajout des traverses avant
            Console.WriteLine("Traverses avant");
            db.Open();
            MySqlCommand cmd10 = db.CreateCommand();
            cmd10.CommandText = "SELECT Code,Largeur,Prix_Client FROM `Composants` WHERE `Ref`= 'Traverse Av' AND`Largeur`=" + box.GetWidth;
            MySqlDataReader reader10 = cmd10.ExecuteReader();
            List<Traverse> forward_traverse_list = new List<Traverse>();

            while (reader10.Read())
            {
                forward_traverse_list.Add(new Traverse(reader10["Code"].ToString(), 0,
                    Convert.ToInt32(reader10["Largeur"]), 0, Convert.ToDouble(reader10["Prix_Client"])));
            }
            db.Close();
            foreach (Traverse traverse in forward_traverse_list)
            {
                Console.WriteLine(traverse.GetPrice);
            }

            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine("Portes avant");
            db.Open();
            MySqlCommand cmd11 = db.CreateCommand();

            cmd11.CommandText = "SELECT Code,Largeur,Hauteur,Couleur,Prix_Client FROM `Composants` WHERE `Ref`= 'Porte ' AND `Largeur`=" + box.GetWidth + " AND `Hauteur`=" +  box.GetHeight;
            MySqlDataReader reader11 = cmd11.ExecuteReader();
            List<Door> door_list = new List<Door>();
            while (reader11.Read())
            {
                door_list.Add(new Door(reader11["Code"].ToString(), Convert.ToInt32(reader11["Hauteur"]),
                    Convert.ToInt32(reader11["Largeur"]), 0, Convert.ToDouble(reader11["Prix_Client"]),
                    reader11["Couleur"].ToString()));
            }
            db.Close();
            foreach(Door door in door_list )
            {
                Console.WriteLine(door.GetColor +" : "+ door.GetPrice);
            }


            //Ajout des cornières adéquates
            db.Open();
            MySqlCommand cmd3 = db.CreateCommand();
            cmd3.CommandText = "SELECT Code,Hauteur,Couleur FROM `Composants` WHERE `Ref`= 'Cornieres' AND `Hauteur`>=" + furniture.GetHeight();

            MySqlDataReader reader3 = cmd3.ExecuteReader();
            List<Tuple<int, string>> list3 = new List<Tuple<int, string>>();
            while (reader3.Read())
            {
                list3.Add(new Tuple<int, string>(Convert.ToInt32(reader3["Hauteur"]), reader3["Couleur"].ToString()));
            }
            db.Close();

            // Composons une petite commande
            //Il faut ajouter des composants à la box !!
            box.AddComponent(side_panel_list[0]);
            box.AddComponent(side_panel_list[0]);
            box.AddComponent(back_panel_list[0]);
            box.AddComponent(horizontal_panel_list[0]);
            box.AddComponent(horizontal_panel_list[0]);
            box.AddComponent(bracket_list[0]);
            box.AddComponent(bracket_list[0]);
            box.AddComponent(bracket_list[0]);
            box.AddComponent(bracket_list[0]);
            box.AddComponent(side_traverse_list[0]);
            box.AddComponent(side_traverse_list[0]);
            box.AddComponent(back_traverse_list[0]);
            box.AddComponent(forward_traverse_list[0]);

            order.AddFurniture(furniture);

            Console.WriteLine("Prix total de la commande : " + order.GetPrice());
            order.WriteFacture("C:\\Users\\Thomas Vandermeersch\\Documents\\Facture_2.markdown");
            Console.WriteLine(furniture.GetType().Name);
        }
    }
}
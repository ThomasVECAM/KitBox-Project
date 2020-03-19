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
            cmd.CommandText = "SELECT Dimension,Largeur,Profondeur,Couleur FROM `Composants` WHERE `Ref`='Panneau HB'";
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

           

            //Choix de la couleur de la box
            db.Open();
            MySqlCommand cmd2_1 = db.CreateCommand();
            cmd2_1.CommandText = "SELECT Couleur FROM `Composants` WHERE `Ref`='Panneau GD' AND `Profondeur`=" + furniture.GetDepth;
            MySqlDataReader reader2_1 = cmd2_1.ExecuteReader();
            List<string> color_list = new List<string>();
            while(reader2_1.Read())
            {
                color_list.Add(reader2_1["Couleur"].ToString());
            }
            color_list = color_list.Distinct().ToList(); //enlever les panneaux de même taille


            Console.WriteLine("Couleur disponnibles");
            foreach(string color in color_list)
            {
                Console.WriteLine(color);
            }
            db.Close();


            Box box = new Box(list2[0], furniture.GetWidth, furniture.GetDepth,color_list[0]); //création d'une box de hauteur de la liste des hauteurs
                                                                                 //Console.WriteLine("Ajout de 2 box de hauteur LISTE 0 des hauteurs au meuble");
            furniture.AddBox(box);
            furniture.AddBox(box); //on ajoute deux box, identiques au meuble(utile pour tester la hauteur des cornières)
            Console.WriteLine("-------------------------------------------------------------");

            Console.WriteLine("Ajout des panneaux");
            box.AddRequiredComponents();
            Console.WriteLine("Panneaux ajoutés");
            
            
            
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
            order.AddFurniture(furniture);

            Console.WriteLine("Prix total de la commande : " + order.GetPrice());
            //order.WriteFacture("C:\\Users\\Thomas Vandermeersch\\Documents\\Facture_2.markdown");
        }
    }
}
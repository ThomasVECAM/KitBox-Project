﻿using System;
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
            }
            //Create a order
            Order order = new Order();

            //First page list
            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = "SELECT Dimension,Largeur,Profondeur FROM `Composants` WHERE `Ref`='Panneau HB'";
            
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Tuple<string,int,int>> list = new List<Tuple<string,int,int>>();
            
            while (reader.Read())
            {
                string dimensions = reader["Dimension"].ToString();
                int width = Int32.Parse(reader["Largeur"].ToString());
                int depth = Int32.Parse(reader["Profondeur"].ToString());
                
                Tuple<string, int, int> tuple = new Tuple<string, int, int>(dimensions,width,depth);
                list.Add(tuple);
            }
            list = list.Distinct().ToList();
            foreach (Tuple<string,int,int> element in list)
            {
                Console.WriteLine(element.Item1);
            }
            db.Close();
            Console.WriteLine("------------------------------------------------------------");

            Console.WriteLine("Ajout d'un meuble");
            //Une fois l'élement sélectionné, on va ajouter des meubles
            Furniture furniture = new Furniture(list[2].Item2,list[2].Item3); 
            order.AddFurniture(furniture);
            furniture.Name = "Meuble 1";
            Console.WriteLine("Nom du meuble");
            Console.WriteLine(furniture.Name);

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Ajout d'une box");

            Console.WriteLine("Choix de la hauteur de la box");
            //Création d'une liste avec les hauteurs possibles

            db.Open();
            MySqlCommand cmd2 = db.CreateCommand();
            cmd2.CommandText = "SELECT Ref,Hauteur,Profondeur FROM `Composants` WHERE `Ref`='Panneau GD' AND `Profondeur`="+furniture.GetDepth;

            MySqlDataReader reader2 = cmd2.ExecuteReader();
            List<int> list2 = new List<int>();
            
            while(reader2.Read())
            {
                int hauteur = Int32.Parse(reader2["Hauteur"].ToString());
                list2.Add(hauteur);
            }
            list2 = list2.Distinct().ToList();
            foreach (int value in list2)
            {
                Console.WriteLine(value);
            }
            db.Close();

            //On peut voir les hauteurs donc la sélectionner, on peut alors créer une box
            Box box = new Box(furniture.GetWidth,furniture.GetDepth,list2[0]);
            
            Console.WriteLine("Ajout de 2 box de hauteur LISTE 0 des hauteurs au meuble");

            furniture.AddBox(box);
            furniture.AddBox(box);
            Console.WriteLine("-------------------------------------------------------------");

            //Ajout des cornières adéquates
            Console.WriteLine(furniture.GetHeight());
            db.Open();
            MySqlCommand cmd3 = db.CreateCommand();
            cmd3.CommandText = "SELECT Code,Hauteur,Couleur FROM `Composants` WHERE `Ref`= 'Cornieres' AND `Hauteur`>="+furniture.GetHeight();

            MySqlDataReader reader3 = cmd3.ExecuteReader();
            List<Tuple<int,string>> list3 = new List<Tuple<int, string>>();
            while(reader3.Read())
            {
                int height = Int32.Parse(reader3["Hauteur"].ToString());
                string color = reader3["Couleur"].ToString();
                Tuple<int,string> tuple2 = new Tuple<int, string>(height, color);
                list3.Add(tuple2);
            }
            db.Close();
            foreach(Tuple<int,string> element in list3)
            {
                Console.WriteLine(element.Item1 + "   :   " + element.Item2);
            }
        }
    }
}
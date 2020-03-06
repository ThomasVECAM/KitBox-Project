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
            }
            //Create a order
            Order order = new Order();

            //First page list
            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = "SELECT Dimension,Largeur,Profondeur FROM `Composants` WHERE `Ref`='Panneau HB'";
            
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> list = new List<string>();
            
            while (reader.Read())
            {
                string dimensions = reader["Dimension"].ToString();
                list.Add(dimensions);
            }
            list = list.Distinct().ToList();
            foreach (string element in list)
            {
                Console.WriteLine(element);
            }


            //Une fois l'élement sélectionné, on va ajouter des meubles

            db.Close();

        }
    }
}


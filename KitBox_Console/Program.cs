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
            MySqlConnection db = new MySqlConnection("SERVER=db4free.net;PORT=3306;DATABASE=groupe5;UID=groupe5;PWD=4c66dfc7; old guids=true");

            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = "SELECT Dimension FROM `Composants` WHERE `Ref`='Panneau HB'";

            try
            {
                db.Open();
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro" + erro);
            }

            MySqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Dimension des meubles");

            List<string> l = new List<string>();
            while (reader.Read())
            {
                string dimensions = reader["Dimension"].ToString();
                l.Add(dimensions);
            }
            db.Close();
            l = l.Distinct().ToList();
            foreach (string element in l)
            {
                Console.WriteLine(element);
            }
        }
    }
}


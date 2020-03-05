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
            cmd.CommandText = "SELECT * FROM `Composants` WHERE `Ref`='Panneau HB'";

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

            while (reader.Read())
            {
                string largeur = reader["Largeur"].ToString();
                string profondeur = reader["Profondeur"].ToString();
                Console.WriteLine(largeur + "x" + profondeur);
            }
            db.Close();
        }
    }
}

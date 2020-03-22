using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Testdb
{
    public partial class Form1 : Form

    {
        MySqlConnection db = new MySqlConnection("SERVER=db4free.net;PORT=3306;DATABASE=groupe5;UID=groupe5;PWD=4c66dfc7; old guids=true");
        List<string> mylist = new List<string>(new string[] { "SELECT Dimension,Largeur,Profondeur,Couleur FROM `Composants` WHERE `Ref`='Panneau HB'", "SELECT Dimension, Largeur, Profondeur, Couleur FROM `Composants` WHERE `Ref`= 'Panneau Ar'", "SELECT Dimension,Largeur,Profondeur,Couleur FROM `Composants` WHERE `Ref`='Panneau HB'" });
        public Form1()
        {
            
           

            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                db.Open();
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro" + erro);
            }
            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = "SELECT ID,ID_CLIENT FROM `Commande` ";
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            dataGridView1.CurrentCell.Selected = false;
            /*while (reader.Read())
            {
                lb1.Items.Add(reader["ID"].ToString() + reader["ID_CLIENT"].ToString()) ;
            }*/
            db.Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lb1.Items.Clear();
            try
            {
                db.Open();
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro" + erro);
            }
            MySqlCommand cmd = db.CreateCommand();
            var random = new Random();
            int index = random.Next(mylist.Count);
            cmd.CommandText = mylist[index];
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lb1.Items.Add(reader["Dimension"].ToString()+reader["Largeur"].ToString()+ reader["Profondeur"].ToString());
            }
            db.Close();
        }
    }
}

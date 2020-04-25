using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.OleDb;

namespace Testdb
{
    public partial class Form1 : Form

    {   

        MySqlConnection db = new MySqlConnection("SERVER=db4free.net;PORT=3306;DATABASE=groupe5;UID=groupe5;PWD=4c66dfc7; old guids=true");
        DataSet myDS = new DataSet();
        DataTable dt2 = new DataTable();

        public Form1()
        {

            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool connected = false;
            while(!connected)
            {
                try
                {
                    db.Open();
                    connected = true;
                }
                catch{}
            }

            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = "SELECT Commande.ID,Client.Nom FROM Commande INNER JOIN Client  ON Commande.ID_Client = Client.ID ";
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            db.Close();
        }
        void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool connected = false;
            while (!connected)
            {
                try
                {
                    db.Open();
                    connected = true;
                }
                catch { }
            }
            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = "SELECT Composant_Commande.Component_Number,Composant_Commande.Meuble,Composant_Commande.Box,"
                + "Composants.Ref, Composants.Dimension,Composants.Couleur,Composants.Nb_Pièces_casier "
                + "FROM Composant_Commande "
                +"INNER JOIN Composants ON Composant_Commande.ID_Composant = Composants.Code WHERE ID_Commande =" 
                + dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView2.DataSource = dt;
            db.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool connected = false;
            while (!connected)
            {
                try
                {
                    db.Open();
                    connected = true;
                }
                catch { }
            }
            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = "DELETE FROM Composant_Commande WHERE ID_Commande=" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() ;
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = (DataTable)(dataGridView1.DataSource);
            foreach(DataGridViewRow item in dataGridView1.SelectedRows)
            {
                dt.Rows[item.Index].Delete();
            }
            db.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(); // This is bad
            f.Show();
        }
    }
}
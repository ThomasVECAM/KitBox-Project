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

        Form2 f2 = new Form2();
        Form3 f3 = new Form3();// This is bad

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
            DataTable dt3 = new DataTable();
            cmd.CommandText = "SELECT Client.ID, Client.Nom,Client.Phone,Client.Email,Client.Adresse,Client.Commune,Client.Code_Postal,Client.TVA FROM Client INNER JOIN Commande ON Client.ID=Commande.ID_Client WHERE Commande.ID = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            reader = cmd.ExecuteReader();
            dt3.Load(reader);
            dataGridView3.DataSource = dt3;
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
            
            db.Close();
            connected = false;
            while (!connected)
            {
                try
                {
                    db.Open();
                    connected = true;
                }
                catch { }
            }
            cmd.CommandText = "DELETE FROM Commande WHERE ID="+dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            reader = cmd.ExecuteReader();
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            

            
            db.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                f2.Show();
            }
            catch
            {
                bool bFormNameOpen=false;
                FormCollection fc = Application.OpenForms;

                foreach (Form frm in fc)
                {
                    //iterate through
                    if (frm.GetType() == f2.GetType())
                    {
                        bFormNameOpen = true;
                    }
                }
                if (bFormNameOpen==true)
                {

                }
                else
                {
                    f2 = new Form2();
                    f2.Show();
                }
                
            }
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.Open();
            DataTable dt = (DataTable)(dataGridView3.DataSource);

            dt.TableName = "Table";

            try
            {

                myDS.Tables.Add(dt);
            }
            catch
            {

            }

            MySqlDataAdapter dataAdapter1 = new MySqlDataAdapter("SELECT * FROM Client WHERE ID= "+dataGridView3.Rows[0].Cells[0].Value.ToString(), db);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(myDS, "Client");
            dataAdapter1.Update(myDS);

            db.Close();
            System.Windows.Forms.MessageBox.Show("Successfully updated");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                f3.Show();
            }
            catch
            {
                bool bFormNameOpen = false;
                FormCollection fc = Application.OpenForms;

                foreach (Form frm in fc)
                {
                    //iterate through
                    if (frm.GetType() == f3.GetType())
                    {
                        bFormNameOpen = true;
                    }
                }
                if (bFormNameOpen == true)
                {

                }
                else
                {
                    f3 = new Form3();
                    f3.Show();
                }

            }
        }
    }
}
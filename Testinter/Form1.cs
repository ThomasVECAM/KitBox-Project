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
            cmd.CommandText = "SELECT * FROM Commande WHERE Validation = 0 ";
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            try
            {
               
                db.Close();
            }
            catch
            {
                db.Close();
            }
            
            
            
            
            
           
           
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
            

            cmd.CommandText = "Select Ref,Profondeur,Hauteur,Largeur,Couleur from Composants WHERE Code IN (SELECT ID_Composant FROM Composant_Commande WHERE ID_Commande =" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + ")";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lb1.Items.Add(reader["Ref"]+": Dimension ="+reader["Largeur"]+"x" +reader["Profondeur"]+"x"+reader["Hauteur"]+", Couleur ="+reader["Couleur"]);
            }
            db.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.Open();
            DataTable dt = (DataTable)(dataGridView1.DataSource);
            
            dt.TableName = "Table";
            try
            {
                
                myDS.Tables.Add(dt);
            }
            catch
            {
                
            }

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT * FROM Commande ", db);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(dataAdapter);
           
            dataAdapter.Fill(myDS, "Commande");
            dataAdapter.Update(myDS);
            
            db.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.Open();
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(); // This is bad
            f.Show();
        }
    }
}


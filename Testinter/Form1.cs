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
            // "Select Code,Ref,Profondeur,Hauteur,Largeur,Couleur from Composants WHERE Code IN (
            lb1.Items.Clear();
            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = "SELECT Component_Number,ID_Composant FROM Composant_Commande WHERE ID_Commande =" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            MySqlCommand cmd2 = db.CreateCommand();
            cmd2.CommandText= "Select Code,Ref,Profondeur,Hauteur,Largeur,Couleur from Composants WHERE Code IN (SELECT ID_Composant FROM Composant_Commande WHERE ID_Commande =" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() +")";
            try
            {
                db.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt2.Clear();
                dt2.Load(reader);
                db.Close();
                db.Open();
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    lb1.Items.Add(reader2["Ref"]+" "+reader2["Code"]+": Dimension ="+reader2["Largeur"]+"x" +reader2["Profondeur"]+"x"+reader2["Hauteur"]+", Couleur ="+reader2["Couleur"]);
                    
                }
            }
                catch (Exception) { }
            dataGridView2.DataSource = dt2;
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


        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(); // This is bad
            f.Show();
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}


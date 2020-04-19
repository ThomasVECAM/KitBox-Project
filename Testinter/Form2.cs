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
    public partial class Form2 : Form
    {
        MySqlConnection db = new MySqlConnection("SERVER=db4free.net;PORT=3306;DATABASE=groupe5;UID=groupe5;PWD=4c66dfc7; old guids=true");
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataSet myDS = new DataSet();
        DataSet myDS2 = new DataSet();
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
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
            cmd.CommandText = "SELECT * FROM Composants ";
            MySqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            dataGridView1.CurrentCell.Selected = false;
            cmd.CommandText = "SELECT * FROM Commande_Fournisseur";
            reader = cmd.ExecuteReader();
            dt2.Load(reader);
            dataGridView2.DataSource = dt2;
            try
            {
                db.Open();
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro" + erro);
            }
            cmd.CommandText = "SELECT ID_Fournisseur,Code_composant FROM Composants_Fournisseurs WHERE (Code_composant,Prix) in(SELECT Code_composant,MIN(Prix) Prix FROM Composants_Fournisseurs GROUP BY Code_composant)";
            reader = cmd.ExecuteReader();
            dt3.Load(reader);
            dataGridView3.DataSource = dt3;
            db.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {


                try
                {
                    if (Int32.Parse(row.Cells["En_Stock"].Value.ToString()) < Int32.Parse(row.Cells["Stock_Minimum"].Value.ToString()))
                    {
                        DataRow added = dt2.NewRow();
                       
                            foreach(DataGridViewRow fourn in dataGridView3.Rows) 
                        {
                            if (fourn.Cells["Code_composant"].Value.ToString() == row.Cells["Code"].Value.ToString())
                            {
                                added["ID_Fournisseur"] = fourn.Cells["ID_Fournisseur"].Value;
                                break;
                            }
                        }
                        added["ID_Composant"] = row.Cells["Code"].Value;
                        added["Validation"] = false;
                        added["Quantity"] = Int32.Parse(row.Cells["En_Stock"].Value.ToString()) - Int32.Parse(row.Cells["Stock_Minimum"].Value.ToString());
                        dt2.Rows.Add(added);
                       
                    }
                }
                catch
                {

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                    bool check = bool.Parse(row.Cells["Validation"].Value.ToString());
                    if (check == true)
                    {
                        int compIndex;
                        string searchValue = row.Cells["ID_Composant"].Value.ToString();
                        foreach (DataGridViewRow comp in dataGridView1.Rows)
                        {
                            if (comp.Cells["Code"].Value.ToString().Equals(searchValue))
                            {
                                compIndex = row.Index;
                                comp.Cells["En_Stock"].Value = Int32.Parse(dataGridView1.Rows[compIndex].Cells["En_Stock"].Value.ToString()) + Int32.Parse(row.Cells["Quantity"].Value.ToString());
                                break;
                            }
                        }
                        dataGridView2.Rows.Remove(row);
                        
                    }
                }
            }

        private void button3_Click(object sender, EventArgs e)
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

            MySqlDataAdapter dataAdapter1 = new MySqlDataAdapter("SELECT * FROM Composants ", db);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(myDS, "Composants");
            dataAdapter1.Update(myDS);

            db.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            db.Open();
            
            DataTable dt2 = (DataTable)(dataGridView2.DataSource);
            
            dt2.TableName = "Table";
            try
            {
                myDS.Tables.Add(dt2);
            }
            catch
            {

            }
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT * FROM Commande_Fournisseur ", db);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(myDS2,"Commande_Fournisseur");
            dataAdapter.Update(myDS2);

            db.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            db.Open();
            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = "DELETE  FROM Composant WHERE Code ='" + dataGridView1.SelectedRows[0].Cells["Code"].Value.ToString() +"'";
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = (DataTable)(dataGridView1.DataSource);
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                dt.Rows[item.Index].Delete();
            }
            db.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            db.Open();
            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = "DELETE  FROM Commande_Fournisseur WHERE ID_Composant = '" + dataGridView2.SelectedRows[0].Cells["ID_Composant"].Value.ToString() + "'";
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt2 = (DataTable)(dataGridView2.DataSource);
            foreach (DataGridViewRow item in dataGridView2.SelectedRows)
            {
                dt2.Rows[item.Index].Delete();
            }
            db.Close();
        }

       


    }
    }


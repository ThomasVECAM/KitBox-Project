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
        DataSet myDS = new DataSet();
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
            db.Close();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                count += 1;

                try
                {
                    if (Int32.Parse(row.Cells["En_Stock"].Value.ToString()) > Int32.Parse(row.Cells["Stock_Minimum"].Value.ToString()))
                    {
                        //listBox1.Items.Add(row.Cells["Code"].Value.ToString() + " Stock suffisant ligne " + count.ToString());
                        DataRow added = dt2.NewRow();
                        added["ID_Fournisseur"] = 1;
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
        }
    }


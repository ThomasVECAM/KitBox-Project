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
using MySqlX.XDevAPI.Relational;

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
        Form3 f3 = new Form3();
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
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
            cmd.CommandText = "SELECT * FROM Composants ";
            MySqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            dataGridView1.CurrentCell.Selected = false;
            cmd.CommandText = "SELECT * FROM Commande_Fournisseur";
            reader = cmd.ExecuteReader();
            dt2.Load(reader);
            dataGridView2.DataSource = dt2;
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
            //cmd.CommandText = "SELECT ID_Fournisseur,Code_composant FROM Composants_Fournisseurs WHERE (Code_composant,Prix) in(SELECT Code_composant,MIN(Prix) Prix FROM Composants_Fournisseurs GROUP BY Code_composant)";
            cmd.CommandText = "SELECT * FROM Composants_Fournisseurs";
            reader = cmd.ExecuteReader();
            dt3.Load(reader);
            dataGridView3.DataSource = dt3;
            db.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        Dictionary<string, int> meilleurFournisseur(string code)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic["Prix"] = 0;
            dic["Fournisseur"] = 0;
            dic["Delai"] = 0;
            foreach (DataGridViewRow fourn in dataGridView3.Rows)
            {
                if (fourn.Cells["Code_composant"].Value.ToString() == code && dic["Prix"] == 0)
                {
                    dic["Prix"] = (int)float.Parse(fourn.Cells["Prix"].Value.ToString()) * 100;
                    dic["Delai"] = Int32.Parse(fourn.Cells["Delai"].Value.ToString());
                    dic["Fournisseur"] = Int32.Parse(fourn.Cells["ID_Fournisseur"].Value.ToString());
                }
                else
                {
                    if ((int)float.Parse(fourn.Cells["Prix"].Value.ToString()) * 100 < dic["Prix"])
                    {
                        dic["Prix"] = (int)(float.Parse(fourn.Cells["Prix"].Value.ToString()) * 100);
                        dic["Fournisseur"] = Int32.Parse(fourn.Cells["ID_Fournisseur"].Value.ToString());
                        dic["Delai"] = Int32.Parse(fourn.Cells["Delai"].Value.ToString());
                    }
                    else if ((int)float.Parse(fourn.Cells["Prix"].Value.ToString()) * 100 == dic["Prix"])
                    {
                        if (dic["Delai"] >= Int32.Parse(fourn.Cells["Delai"].Value.ToString()))
                        {
                            dic["Prix"] = (int)float.Parse(fourn.Cells["Prix"].Value.ToString()) * 100;
                            dic["Fournisseur"] = Int32.Parse(fourn.Cells["ID_Fournisseur"].Value.ToString());
                            dic["Delai"] = Int32.Parse(fourn.Cells["Delai"].Value.ToString());
                        }
                        else
                        {

                        }
                    }
                }
            }

            return dic;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                try
                {



                    if (Int32.Parse(row.Cells["En_Stock"].Value.ToString()) > Int32.Parse(row.Cells["Stock_Minimum"].Value.ToString()))
                    {
                        DataRow added = dt2.NewRow();

                        Dictionary<string, int> dic = meilleurFournisseur(row.Cells["Code"].Value.ToString());
                        // added["Prix"]=dic["Prix"]/100;
                        // added["Delai"]= dic["Delai"];
                        added["ID_Fournisseur"] = dic["Fournisseur"];
                        added["ID_Composant"] = row.Cells["Code"].Value;
                        added["Validation"] = false;
                        added["Quantity"] = Int32.Parse(row.Cells["En_Stock"].Value.ToString()) - Int32.Parse(row.Cells["Stock_Minimum"].Value.ToString());
                        dt2.Rows.Add(added);

                    }
                }
                catch { }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                bool check = bool.Parse(row.Cells["Validation"].Value.ToString());
                if (check == true)
                {
                    string searchValue = row.Cells["ID_Composant"].Value.ToString();
                    foreach (DataGridViewRow comp in dataGridView1.Rows)
                    {
                        if (row.Cells["ID_Composant"].Value.ToString() == comp.Cells["Code"].Value.ToString())
                        {
                            comp.Cells["En_Stock"].Value = Int32.Parse(comp.Cells["En_Stock"].Value.ToString()) + Int32.Parse(row.Cells["Quantity"].Value.ToString());
                            break;
                        }
                    }
                    dataGridView2.Rows.Remove(row);

                }
            }
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
            System.Windows.Forms.MessageBox.Show("Successfully updated");
        }

        private void button4_Click(object sender, EventArgs e)
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
            dataAdapter.Fill(myDS2, "Commande_Fournisseur");
            dataAdapter.Update(myDS2);
            System.Windows.Forms.MessageBox.Show("Successfully updated");
            db.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
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
            cmd.CommandText = "DELETE  FROM Composant WHERE Code ='" + dataGridView1.SelectedRows[0].Cells["Code"].Value.ToString() + "'";
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
            cmd.CommandText = "DELETE  FROM Commande_Fournisseur WHERE ID_Composant = '" + dataGridView2.SelectedRows[0].Cells["ID_Composant"].Value.ToString() + "'";
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt2 = (DataTable)(dataGridView2.DataSource);
            foreach (DataGridViewRow item in dataGridView2.SelectedRows)
            {
                dt2.Rows[item.Index].Delete();
            }
            db.Close();
        }

        private void button7_Click(object sender, EventArgs e)
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


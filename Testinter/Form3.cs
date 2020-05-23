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
    public partial class Form3 : Form
    {
        MySqlConnection db = new MySqlConnection("SERVER=db4free.net;PORT=3306;DATABASE=groupe5;UID=groupe5;PWD=4c66dfc7; old guids=true");
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataSet myDS = new DataSet();
        DataSet myDS2 = new DataSet();
        public Form3()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
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
            cmd.CommandText = "SELECT * FROM Composants_Fournisseurs";
            MySqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            cmd.CommandText = "SELECT * FROM Fournisseurs";
            reader = cmd.ExecuteReader();
            dt2.Load(reader);
            dataGridView2.DataSource = dt2;
            db.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT * FROM Composants_Fournisseurs ", db);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(myDS, "Composants_Fournisseurs");
            dataAdapter.Update(myDS);
            System.Windows.Forms.MessageBox.Show("Successfully updated");
            db.Close();
        }

        private void button2_Click(object sender, EventArgs e)
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
                myDS2.Tables.Add(dt2);
            }
            catch
            {

            }
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT * FROM Fournisseurs", db);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(myDS2, "Fournisseurs");
            dataAdapter.Update(myDS2);
            System.Windows.Forms.MessageBox.Show("Successfully updated");
            db.Close();
        }
    }
}

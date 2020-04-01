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
            db.Close();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                listBox1.Items.Add(row.Cells[0].Value.ToString());
                
            }
        }
    }
}

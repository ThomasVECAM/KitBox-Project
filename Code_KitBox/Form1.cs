using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Interface_5
{
    public partial class Form1 : Form
    {
        private int commandId;
        public Form1()
        {
            Globals.dataBaseComponents = new DataBaseComponents();

            MySqlConnection db = new MySqlConnection("SERVER=mysql-projetkitbox.alwaysdata.net;PORT=3306;DATABASE=projetkitbox_db;UID=207353_thomas	;PWD=Y@sqydv6Yp798Xy; old guids=true");
            bool connected = false;
            while (!connected)
                try
                {
                    db.Open();
                    connected = true;
                }
                catch (Exception){}
            
            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = "SELECT MAX(ID) FROM `Client`";
            string answer = cmd.ExecuteScalar().ToString();
            if(answer == "")
                Globals.customerId = 1;
            else
                Globals.customerId = Convert.ToInt32(answer) + 1;
            db.Close();
            connected = false;
            while (!connected)
                try
                {
                    db.Open();
                    connected = true;
                }
                catch (Exception) { }

            MySqlCommand cmd2 = db.CreateCommand();
            cmd.CommandText = "SELECT MAX(ID) FROM `Commande`";
            string answer2 = cmd.ExecuteScalar().ToString();
            if (answer == "")
                commandId = 1;
            else
                commandId = Convert.ToInt32(answer2) + 1;
            db.Close();
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Globals.order = new Order(commandId);
            UserControl1 First1User = new UserControl1();
            startPanel.Controls.Clear();
            startPanel.Controls.Add(First1User);
        }
    }
}
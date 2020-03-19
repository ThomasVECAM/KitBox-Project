using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Interface_5
{
    public partial class UserControl1 : UserControl
    {
        public static string transDimensions = "";
        private static UserControl1 _instance;
        private String[] widthDepth;

       
        public static UserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl1();
                return _instance;
            }
        }
        public UserControl1()
        {
            InitializeComponent();
            MySqlConnection db = new MySqlConnection("SERVER=db4free.net;PORT=3306;DATABASE=groupe5;UID=groupe5;PWD=4c66dfc7; old guids=true");
            try
            {
                db.Open();
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro" + erro);
            }

            //Choix dimensions meuble - en fonction des plaques horizontales existantes
            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = "SELECT Dimension,Largeur,Profondeur,Couleur FROM `Composants` WHERE `Ref`='Panneau HB'";
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Tuple<string, int, int>> dimension_list = new List<Tuple<string, int, int>>(); //liste où l'on va stocker les composants
            while (reader.Read())
            {
                dimension_list.Add(new Tuple<string, int, int>(reader["Dimension"].ToString(),
                    Convert.ToInt32(reader["Largeur"]), Convert.ToInt32(reader["Profondeur"])));
            }
            db.Close();
            dimension_list = dimension_list.Distinct().ToList(); //enlever les panneaux de même taille

            foreach (Tuple<string, int, int> element in dimension_list)
            {
                widthDepthComboBox.Items.Add(element.Item2 + "x" + element.Item3); 
            }

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        public void NextButton_Click(object sender, EventArgs e)
        {
            
            Globals.order.AddFurniture(Convert.ToInt32(widthDepth[0]), Convert.ToInt32(widthDepth[1]));
            if (!sizePanel.Controls.Contains(UserControl2.Instance))
            {
                sizePanel.Controls.Add(UserControl2.Instance);
                UserControl2.Instance.Dock = DockStyle.Fill;
                UserControl2.Instance.BringToFront();
            }
            else
            {
                UserControl2.Instance.BringToFront();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
           
        }


        private void WidthDepthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] separator = { 'x' };
            Int32 tokens = 2;
            widthDepth = widthDepthComboBox.SelectedItem.ToString().Split(separator, tokens, StringSplitOptions.None);
            widthLabel.Text = widthDepth[0];
            depthLabel.Text = widthDepth[1];
            transDimensions = widthLabel.Text + "x" + depthLabel.Text+"x";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
 
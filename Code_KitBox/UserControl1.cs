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
            
            List<string> dimension_list = new List<string>(); //liste où l'on va stocker les dimensions

            foreach (Component component in Globals.requiredComponents.horizontalPanelList)
            {
                    dimension_list.Add(component.GetWidth + "x" + component.GetDepth);
            }
            dimension_list = dimension_list.Distinct().ToList(); //enlever les panneaux de même taille

            foreach (string element in dimension_list)
            {
                widthDepthComboBox.Items.Add(element); 
            }
        }
        public void NextButton_Click(object sender, EventArgs e)
        {
            Globals.order.AddFurniture(Convert.ToInt32(widthDepth[0]), Convert.ToInt32(widthDepth[1]));
            Globals.furnitureIndex = Globals.order.GetFurnitureList.Count - 1;
            sizePanel.Controls.Clear();
            sizePanel.Controls.Add(new UserControl2());
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
    }
}
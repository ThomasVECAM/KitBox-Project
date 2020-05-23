using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Interface_5
{
    public partial class UserControl1 : UserControl
    {
        public static string transDimensions = "";
        private String[] widthDepth;
        public UserControl1()
        {
            InitializeComponent();
            List<string> dimension_list = new List<string>(); //liste où l'on va stocker les dimensions
            foreach (Component component in Globals.dataBaseComponents.horizontalPanelList)
                    dimension_list.Add(component.GetWidth + "x" + component.GetDepth);
            dimension_list = dimension_list.Distinct().ToList(); //enlever les panneaux de même taille
            foreach (string element in dimension_list)
                widthDepthComboBox.Items.Add(element); 
        }
        public void NextButton_Click(object sender, EventArgs e)
        {
            if (widthDepthComboBox.SelectedIndex > -1)
            {
                Globals.order.AddFurniture(Convert.ToInt32(widthDepth[0]), Convert.ToInt32(widthDepth[1]));
                int furnitureCount = Globals.order.GetFurnitureList.Count;
                Globals.furnitureIndex = furnitureCount - 1;
                Globals.order.GetFurnitureList[Globals.furnitureIndex].Name = "Furniture " + furnitureCount.ToString();

                sizePanel.Controls.Clear();
                sizePanel.Controls.Add(new UserControl2());
            }
            else
                MessageBox.Show("Please select width and depth");
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
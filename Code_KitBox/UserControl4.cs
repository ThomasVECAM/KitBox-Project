using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface_5
{
    public partial class UserControl4 : UserControl
    {
        private int indiceFurnitureList;

        public UserControl4(int indiceFurnitureList)
        {
            this.indiceFurnitureList = indiceFurnitureList;
            InitializeComponent();
            UpdateFurniturePanel();
        }
        public Button Modify
        {
            get{ return modifyButton; }
        }

        public Button Remove
        {
            get { return removeButton; }
        }

        private void UpdateFurniturePanel()
        {
            nbFurnitureLabel.Text = "X " + Globals.order.GetFurnitureList[indiceFurnitureList].nbFurnitures.ToString();
            LabelFurnitureName.Text = Globals.order.GetFurnitureList[indiceFurnitureList].Name;
            LabelNrOfBoxes.Text = Globals.order.GetFurnitureList[indiceFurnitureList].GetBoxList.Count().ToString();
            LabelFurnitureDimensions.Text = Globals.order.GetFurnitureList[indiceFurnitureList].GetHeight().ToString()
                + "x" + Globals.order.GetFurnitureList[indiceFurnitureList].GetWidth.ToString()
                + "x" + Globals.order.GetFurnitureList[indiceFurnitureList].GetDepth.ToString();
            
            if (Globals.order.GetFurnitureList[indiceFurnitureList].InStock())
                stockLabel.BackColor = Color.Lime;
            else
                stockLabel.BackColor = Color.Red;
        }

        private void modifyButton_Click_1(object sender, EventArgs e)
        {
            Globals.furnitureIndex = indiceFurnitureList;
            //rest of function is done in User3
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to remove :" + Globals.order.GetFurnitureList[indiceFurnitureList].Name.ToString()
            , "Exit", MessageBoxButtons.YesNo);
            if(dialog == DialogResult.Yes)
            {
                Globals.furnitureIndex = indiceFurnitureList;
                Globals.order.GetFurnitureList[indiceFurnitureList].RemoveBoxes();
                Globals.order.GetFurnitureList.RemoveAt(indiceFurnitureList);
                //rest of function is done in User3
            }
        }

        private void addnbButton_Click(object sender, EventArgs e)
        {
            Globals.order.GetFurnitureList[indiceFurnitureList].nbFurnitures += 1;
            Globals.furnitureIndex = indiceFurnitureList;
            nbFurnitureLabel.Text = "X " + Globals.order.GetFurnitureList[indiceFurnitureList].nbFurnitures.ToString();
        }

        private void removenbButton_Click(object sender, EventArgs e)
        {
            int actualnbFurniture = Globals.order.GetFurnitureList[indiceFurnitureList].nbFurnitures;
            if (actualnbFurniture == 1)
            {
                MessageBox.Show("You need at least 1 of this furniture !, if you want 0 of them : Click Remove");
            }
            else
            {
                Globals.order.GetFurnitureList[indiceFurnitureList].nbFurnitures--;
                Globals.furnitureIndex = indiceFurnitureList;
                nbFurnitureLabel.Text = "X " + Globals.order.GetFurnitureList[indiceFurnitureList].nbFurnitures.ToString();
            }
        }
    }
}
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
        public Button Duplicate
        {
            get { return duplicateButton; }
        }
        public Button Remove
        {
            get { return removeButton; }
        }

        private void UpdateFurniturePanel()
        {
            LabelFurnitureName.Text = Globals.order.GetFurnitureList[indiceFurnitureList].Name;
            LabelNrOfBoxes.Text = Globals.order.GetFurnitureList[indiceFurnitureList].GetBoxList.Count().ToString();
            LabelFurnitureDimensions.Text = Globals.order.GetFurnitureList[indiceFurnitureList].GetHeight().ToString()
                + "x" + Globals.order.GetFurnitureList[indiceFurnitureList].GetWidth.ToString()
                + "x" + Globals.order.GetFurnitureList[indiceFurnitureList].GetDepth.ToString();
        }

        private void modifyButton_Click_1(object sender, EventArgs e)
        {
            Globals.furnitureIndex = indiceFurnitureList;
            //rest of function is done in User3
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            Globals.furnitureIndex = indiceFurnitureList;
            Globals.order.GetFurnitureList.RemoveAt(indiceFurnitureList);
            //rest of function is done in User3
        }

        private void duplicateButton_Click(object sender, EventArgs e)
        {
            Globals.furnitureIndex = indiceFurnitureList;
            Globals.order.Duplicate();
        }
    }
}
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
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private static UserControl3 _instance;
        public static UserControl3 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl3();
                return _instance;
            }
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            FurnitureItems();
        }
        public void FurnitureItems()
        {
            /*
           UserControl4 [] listItems = new UserControl4[20];

           for(int i=0; i< listItems.Length;i++)
           {
               listItems[i] = new UserControl4();
               listItems[i].FurnitureName = "Meuble Cuisine";
               listItems[i].FurnitureDimensions = "240x40x300";

               if(flowLayoutPanel1.Controls.Count <0)
               {
                   flowLayoutPanel1.Controls.Clear();

               }
               else
               flowLayoutPanel1.Controls.Add(listItems[i]);
           }*/
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FurnitureDetails_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

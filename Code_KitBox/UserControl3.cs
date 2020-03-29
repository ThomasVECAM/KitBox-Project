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
            
            for (int i=0;  i < Globals.order.GetFurnitureList.Count; i++)
            {
                UserControl4 furnitureTemplate = new UserControl4(i);
                furnitureTemplate.Modify.Click += new EventHandler(Modify);
                furnitureTemplate.Remove.Click += new EventHandler(Remove_Duplicate);
                //furnitureTemplate.Duplicate.Click += new EventHandler(Remove_Duplicate);
                flowLayoutPanel1.Controls.Add(furnitureTemplate);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new UserControl1());
        }
        private void Modify(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new UserControl2());
        }
        private void Remove_Duplicate(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new UserControl3());
            // new page that will be an update
        }
    }
}
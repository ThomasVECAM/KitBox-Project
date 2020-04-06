using System;
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
                furnitureTemplate.Remove.Click += new EventHandler(Remove);
                furnitureTemplate.AddnbButton.Click += new EventHandler(Update);
                furnitureTemplate.RemovenbButton.Click += new EventHandler(Update);
                flowLayoutPanel1.Controls.Add(furnitureTemplate);
            }
            orderPrice.Text = "Total price : " + Globals.order.GetPrice().ToString() + " €";
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
        private void Remove(object sender, EventArgs e)
        {
            panel1.Controls.Add(new UserControl3());
        }
        private void Update(object sender, EventArgs e)
        {
            orderPrice.Text = "Total price : " + Globals.order.GetPrice().ToString() + " €";
            foreach(UserControl4 userControl4 in flowLayoutPanel1.Controls)
                userControl4.UpdateFurniturePanel();
        }

        private void finishOrder_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new UserControl5());
        }
    }
}
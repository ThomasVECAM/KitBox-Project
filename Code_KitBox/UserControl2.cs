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
    public partial class UserControl2 : UserControl
    {
        private static UserControl2 _instance;
        public static UserControl2 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl2();
                return _instance;
            }
        }

    
        public UserControl2()
        {
            InitializeComponent();


        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void RadioButton16_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton17_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton18_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton19_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton20_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton21_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton15_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button11_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Panel7_AutoSizeChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button12_Click(object sender, EventArgs e)
        {
            if (!boxesPannel.Controls.Contains(UserControl3.Instance))
            {
                boxesPannel.Controls.Add(UserControl3.Instance);
                UserControl3.Instance.Dock = DockStyle.Fill;
                UserControl3.Instance.BringToFront();
            }
            else
                UserControl3.Instance.BringToFront();
        }

        private void Panel7_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {
            
        }
    }
}

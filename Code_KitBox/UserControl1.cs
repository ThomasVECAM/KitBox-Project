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
    public partial class UserControl1 : UserControl
    {
  
        private static UserControl1 _instance;
      
     
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
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Button2_Click_1(object sender, EventArgs e)
        {


            if (!panel1.Controls.Contains(UserControl2.Instance))
            {
                panel1.Controls.Add(UserControl2.Instance);
                UserControl2.Instance.Dock = DockStyle.Fill;
                UserControl2.Instance.BringToFront();
            }
            else
            {
                UserControl2.Instance.BringToFront();
            }

            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
           
        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {
         
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }
    }
}

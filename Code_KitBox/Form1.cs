using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface_5
{
    public partial class Form1 : Form
    {   
        UserControl1 FirstUser =new UserControl1();

        UserControl2 SecondUser = new UserControl2();

        public Form1()
        {
            InitializeComponent();
      
        }

        void MainWindow_myevent(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void ToolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(UserControl1.Instance))
            {
                panel2.Controls.Add(UserControl1.Instance);
                UserControl1.Instance.Dock = DockStyle.Fill;
                UserControl1.Instance.BringToFront();
            }
            else
                UserControl1.Instance.BringToFront();

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

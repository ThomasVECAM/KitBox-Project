using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testdb
{
    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "1111")
            {
                Form1 f = new Form1();
                f.Show();


            }
            else
            {
                label1.Text = "WRONG PASSWORD";
            }
        }

 
    }
}

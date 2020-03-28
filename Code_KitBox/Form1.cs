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
        public Form1()
        {
            Globals.requiredComponents = new RequiredComponents();
            InitializeComponent();
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            Globals.order = new Order();
            UserControl1 First1User = new UserControl1();
            startPanel.Controls.Clear();
            startPanel.Controls.Add(First1User);
        }
    }
}
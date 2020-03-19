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
        UserControl3 ThirdUser = new UserControl3();

        private static Form1 _instance;
        public Panel StartPanel
        {
            get { return startPanel; }
            set { startPanel =value; }
        }
        public Form1()
        {
            InitializeComponent();
         

        }
        public static Form1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Form1();
                return _instance;
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

    

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (!startPanel.Controls.Contains(UserControl1.Instance))
            {
                startPanel.Controls.Add(UserControl1.Instance);
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

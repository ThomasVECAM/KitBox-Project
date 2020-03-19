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
        public static  string transDimensions = "";
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
            widthDepthComboBox.Items.Add("330x220");
            widthDepthComboBox.Items.Add("220x650");
            widthDepthComboBox.Items.Add("440x800");
            
        }



        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        public void NextButton_Click(object sender, EventArgs e)
        {

            if (!sizePanel.Controls.Contains(UserControl2.Instance))
            {
                sizePanel.Controls.Add(UserControl2.Instance);
                UserControl2.Instance.Dock = DockStyle.Fill;
                UserControl2.Instance.BringToFront();
            }
            else
            {
                UserControl2.Instance.BringToFront();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
           
        }


        private void WidthDepthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] separator = { 'x' };
            Int32 tokens = 2;
            String[] widthDepth = widthDepthComboBox.SelectedItem.ToString().Split(separator, tokens, StringSplitOptions.None);
            widthLabel.Text = widthDepth[0];
            depthLabel.Text = widthDepth[1];
            transDimensions = widthLabel.Text + "x" + depthLabel.Text+"x";
        }
    }
}
 
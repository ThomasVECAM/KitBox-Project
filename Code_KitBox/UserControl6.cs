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
    
    public partial class UserControl6 : UserControl
    {
        public UserControl6()
        {
            InitializeComponent();
            if(!Globals.order.InStock())
            {
                mainLabel.Text = "Your order (n° " + Globals.order.Id + ") is unfortunatly not available.";
                mainLabel2.Text = "To pay a down payement.";
            }
            else
            {
                mainLabel.Text = "Your order (n° " + Globals.order.Id + ") is now available.";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

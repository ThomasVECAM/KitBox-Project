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
                mainLabel.Text = "Your command is unfortunatly not available";
                mainLabel2.Text = "To pay an account";
            }
        }
    }
}

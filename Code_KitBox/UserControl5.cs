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
    public partial class UserControl5 : UserControl
    {
        private string customerStatus = "particular";
        public UserControl5()
        {
            InitializeComponent();
            tvaPannel.Hide();
            checkBoxParticular.Checked = true;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void UserControl5_Load(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxParticular_CheckedChanged(object sender, EventArgs e)
        {
            customerStatus = "particular";
            checkBoxCompany.Checked = false;
            tvaPannel.Hide();
        }

        private void checkBoxCompany_CheckedChanged(object sender, EventArgs e)
        {
            customerStatus = "company";
            checkBoxParticular.Checked = false;
            tvaPannel.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            userControlPannel.Controls.Add(new UserControl3());
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if(customerStatus == "particular")
            {
                new Person(lastname.Text, firstname.Text, phoneNumber.Text,
                    adress.Text, city.Text, postalCode.Text);
            }
            else
            {
                new Company(lastname.Text, firstname.Text, phoneNumber.Text,
                    adress.Text, city.Text, postalCode.Text,tvaNumber.Text);
            }
            userControlPannel.Controls.Clear();
            userControlPannel.Controls.Add(new UserControl6());
        }
    }
}
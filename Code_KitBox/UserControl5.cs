using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


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
            orderNbLabel.Text = "#" + Globals.commandId.ToString();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
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


        private void confirmButton_Click(object sender, EventArgs e)
        {
            confirmButton.Text = "Wait...";
            if (customerStatus == "particular")
            {
                Globals.person = new Person(name.Text, email.Text, phoneNumber.Text,
                    adress.Text, city.Text, Convert.ToInt32(postalCode.Text));
            }
            else
            {
                Globals.company = new Company(name.Text, email.Text, phoneNumber.Text,
                    adress.Text, city.Text,Convert.ToInt32(postalCode.Text),Convert.ToInt32(tvaNumber.Text));
            }


            Globals.order.AddToDB(customerStatus);
            userControlPannel.Controls.Clear();
            userControlPannel.Controls.Add(new UserControl6());
        }

        private void lastname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
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
using System.Text.RegularExpressions;



namespace Interface_5
{
    public partial class UserControl5 : UserControl
    {
        private string customerStatus = "particular";
        bool nameValid = false;
        bool emailValid = false;
        bool phoneValid = false;
        bool adressValid = false;
        bool cityValid = false;
        bool postalCodeValid = false;
        bool TVAValid = true;
        public UserControl5()
        {
            InitializeComponent();
            tvaPannel.Hide();
            checkBoxParticular.Checked = true;
            orderNbLabel.Text = "#" + Globals.commandId.ToString();
        }

        private void UserControl5_Load(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxParticular_CheckedChanged(object sender, EventArgs e)
        {
            TVAValid = true;
            customerStatus = "particular";
            checkBoxCompany.Checked = false;
            tvaPannel.Hide();
        }

        private void checkBoxCompany_CheckedChanged(object sender, EventArgs e)
        {
            TVAValid = false;
            customerStatus = "company";
            checkBoxParticular.Checked = false;
            tvaPannel.Show();
        }


        private void confirmButton_Click(object sender, EventArgs e)
        {
            if(nameValid && emailValid && phoneValid && adressValid 
                && cityValid && postalCodeValid && TVAValid)
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
                        adress.Text, city.Text, Convert.ToInt32(postalCode.Text), Convert.ToInt32(tvaNumber.Text));
                }


                Globals.order.AddToDB(customerStatus);
                userControlPannel.Controls.Clear();
                userControlPannel.Controls.Add(new UserControl6());
            }
            else
            {
                MessageBox.Show("All fields are not Valid");
            }

           
        }

        private void lastname_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[A-Za-z'\-]{3,15}( [A-Za-z'\-]{1,15}){1,5}$");

            Match match = regex.Match(name.Text);
            if (match.Success)
            {
                name.ForeColor = Color.Black;
                nameValid = true;
            }
            else
            {
                name.ForeColor = Color.Red;
                nameValid = false;
            }
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); //email
            Match match =  regex.Match(email.Text);
            if (match.Success)
            {
                email.ForeColor = Color.Black;
                emailValid = true;
            }
            else
            {
                email.ForeColor = Color.Red;
                emailValid = false;

            }

        }

        private void phoneNumber_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^\+{0,1}\d{8,12}$");

            Match match = regex.Match(phoneNumber.Text);
            if (match.Success)
            {
                phoneNumber.ForeColor = Color.Black;
                phoneValid = true;
            }
            else
            {
                phoneNumber.ForeColor = Color.Red;
                phoneValid = false;
            }
        }

        private void adress_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[A-Za-z,\-'0-9 ]{10,30}$");//adresse

            Match match = regex.Match(adress.Text);
            if (match.Success)
            {
                adress.ForeColor = Color.Black;
                adressValid = true;
            }
            else
            {
                adress.ForeColor = Color.Red;
                adressValid = false;
            }
        }

        private void city_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[A-Za-z\'-]{3,25}( [A-Za-z\'-]{3,15}){0,5}$");

            Match match = regex.Match(city.Text);
            if (match.Success)
            {
                city.ForeColor = Color.Black;
                cityValid = true;
            }
            else
            {
                city.ForeColor = Color.Red;
                cityValid = false;
            }
        }

        private void postalCode_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^\d{4,5}$");
            Match match = regex.Match(postalCode.Text);
            if (match.Success)
            {
                postalCode.ForeColor = Color.Black;
                postalCodeValid = true;
            }
            else
            {
                postalCode.ForeColor = Color.Red;
                postalCodeValid = false;
            }
        }

        private void tvaNumber_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^\d{9,13}$");
            Match match = regex.Match(tvaNumber.Text);
            if (match.Success)
            {
                tvaNumber.ForeColor = Color.Black;
                TVAValid = true;
            }
            else
            {
                tvaNumber.ForeColor = Color.Red;
                TVAValid = false;
            }
        }
    }
}
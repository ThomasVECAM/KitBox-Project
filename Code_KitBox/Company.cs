using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_5
{
    class Company : Person
    {
        public string tvaNumber;
        public Company(string name, string firstname, string phone, string adress, string city, string postalCode, string tvaNumber) :
            base( name,  firstname,  phone,  adress,  city, postalCode)
        {
            this.tvaNumber = tvaNumber;
        }
    }
}

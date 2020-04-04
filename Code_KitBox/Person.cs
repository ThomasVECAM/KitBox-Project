using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_5
{
    class Person
    {
        public string name, firstname, phone, adress, city, postalCode;
        public Person(string name, string firstname, string phone, string adress, string city, string postalCode)
        {
            this.name = name;
            this.firstname = firstname;
            this.phone = phone;
            this.adress = adress;
            this.city = city;
            this.postalCode = postalCode;
        }
    }
}

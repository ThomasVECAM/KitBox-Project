﻿using MySql.Data.MySqlClient;

namespace Interface_5
{
    class Company : Person
    {
        public int tvaNumber;
        public Company(int id, string name, string email, string phone, string adress, string city, int postalCode, int tvaNumber) :
            base(id, name,  email,  phone,  adress,  city, postalCode)
        {
            this.tvaNumber = tvaNumber;
        }
        public new void AddToDB()
        {
            //Création du client dans la base de donnée;
            Globals.command = new MySqlCommand("INSERT INTO Client(ID,Nom,Phone,Email,Adresse,Commune,Code_Postal,TVA)" +
                " VALUES(@ID,@Nom,@Phone,@Email,@Adresse,@Commune,@Code_Postal,@TVA)", Globals.db);
            Globals.command.Parameters.AddWithValue("@ID", id);
            Globals.command.Parameters.AddWithValue("@Nom", name);
            Globals.command.Parameters.AddWithValue("@Phone", phone);
            Globals.command.Parameters.AddWithValue("@Email", email);
            Globals.command.Parameters.AddWithValue("@Adresse", adress);
            Globals.command.Parameters.AddWithValue("@Commune", city);
            Globals.command.Parameters.AddWithValue("@Code_Postal", postalCode);
            Globals.command.Parameters.AddWithValue("@TVA", tvaNumber);

            Globals.command.ExecuteNonQuery();
            Globals.command.Parameters.Clear();
        }
    }
}

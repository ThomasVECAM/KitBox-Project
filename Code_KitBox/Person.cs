using MySql.Data.MySqlClient;

namespace Interface_5
{
    class Person
    {
        public string name, email, phone, adress, city; 
        public int postalCode;
        public Person(string name, string email, string phone, string adress, string city, int postalCode)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.adress = adress;
            this.city = city;
            this.postalCode = postalCode;
        }

        public void AddToDB()
        {
            //Création du client dans la base de donnée;
            Globals.command = new MySqlCommand("INSERT INTO Client(ID,Nom,Phone,Email,Adresse,Commune,Code_Postal,TVA)" +
                " VALUES(@ID,@Nom,@Phone,@Email,@Adresse,@Commune,@Code_Postal,0)", Globals.db);
            Globals.command.Parameters.AddWithValue("@ID", Globals.customerId);
            Globals.command.Parameters.AddWithValue("@Nom", name);
            Globals.command.Parameters.AddWithValue("@Phone", phone);
            Globals.command.Parameters.AddWithValue("@Email", email);
            Globals.command.Parameters.AddWithValue("@Adresse", adress);
            Globals.command.Parameters.AddWithValue("@Commune", city);
            Globals.command.Parameters.AddWithValue("@Code_Postal", postalCode);
            Globals.command.ExecuteNonQuery();
            Globals.command.Parameters.Clear();
        }
    }
}

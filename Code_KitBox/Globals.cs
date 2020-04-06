using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Interface_5
{
    static class Globals
    {
        public static int customerId;
        public static int commandId;
        public static Order order;
        public static int furnitureIndex;
        public static DataBaseComponents dataBaseComponents;
        public static MySqlCommand command;
        public static int componentIndex;
        public static Person person;
        public static Company company;
        public static MySqlConnection db;
        public static string MySQLCommandText;
    }
}
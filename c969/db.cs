using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c969
{
    public class db
    {
        private string _connectionString; //the _ prefix is a common naming convention for private fields
        protected MySqlConnection _connection;
        public db(string server, string port,string db, string user, string password)
        {
            _connectionString = $"Data source={server}; Port={port};Initial Catalog ={db};"+
                $"User={user}; Password ={password}";
        }
        public void Connect() //creates the object to open the connection
        {
            _connection = new MySqlConnection(_connectionString);
            _connection.Open();
        }

        public void Disconnect() //closes the connection
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open) // to avoid an exception if the connection is already closed
               
            _connection.Close();
        }
    }
}

using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Client
    {
        private string _clientName;
        private int _id;
        private int _stylistId;

        public Client(string clientName, int stylistId, int id = 0)
        {
            _clientName = clientName;
            _stylistId = stylistId;
            _id = id;
        }
        
        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
        }
    }
}
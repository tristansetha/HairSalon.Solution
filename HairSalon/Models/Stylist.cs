using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Stylist
    {
        private string _stylistName;
        private int _id;
        private string _stylistDetails;

        public Stylist(string stylistName, string stylistDetails, int id = 0)
        {
            _stylistName = stylistName;
            _stylistDetails = stylistDetails;
            _id = id;
        }
        
        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
        }
    }
}
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Stylist
    {
        private string _stylistName;
        private int _id;
        private string _stylistDetails;
        private List<Stylist> _stylists;

        public Stylist(string stylistName, string stylistDetails, int id = 0)
        {
            _stylistName = stylistName;
            _stylistDetails = stylistDetails;
            _id = id;
            _stylists = new List<Stylist> {};
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int StylistId = rdr.GetInt32(0);
                string StylistName = rdr.GetString(1);
                string StylistDetails = rdr.GetString(2);
                Stylist newStylist = new Stylist(StylistName, StylistDetails, StylistId);
                allStylists.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylists;
        }
    }
}
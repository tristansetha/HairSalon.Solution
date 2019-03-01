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
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool idEquality = this.GetId().Equals(newStylist.GetId());
                bool nameEquality = this.GetName().Equals(newStylist.GetName());
                return (idEquality && nameEquality);
            }
        }

        public string GetName()
        {
            return _stylistName;
        }

        public int GetId()
        {
            return _id;
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

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (name, details) VALUES (@stylistName, @stylistDetails);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@stylistName";
            name.Value = this._stylistName;
            cmd.Parameters.Add(name);
            MySqlParameter details = new MySqlParameter();
            details.ParameterName = "@stylistDetails";
            details.Value = this._stylistDetails;
            cmd.Parameters.Add(details);
            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
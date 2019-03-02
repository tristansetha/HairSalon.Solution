using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Stylist
    {
        private string _stylistName;
        private int _id;
        private string _stylistDetails;
        private List<Client> _clients;

        public Stylist(string stylistName, string stylistDetails, int id = 0)
        {
            _stylistName = stylistName;
            _stylistDetails = stylistDetails;
            _id = id;
            _clients = new List<Client> {};
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

        public void AddClient(Client client)
        {
            _clients.Add(client);
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

        // public static void DeleteAll()
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     var cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"DELETE FROM clients";
        //     cmd.ExecuteNonQuery();
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        // }

        public List<Client> GetClients()
        {
            List<Client> allStylistClients = new List<Client> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylist_id;";
            MySqlParameter stylistId = new MySqlParameter();
            stylistId.ParameterName = "@stylist_id";
            stylistId.Value = this._id;
            cmd.Parameters.Add(stylistId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            while(rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);
                int clientStylistId = rdr.GetInt32(2);
                Client newClient = new Client(clientName, clientStylistId, clientId);
                allStylistClients.Add(newClient);
            }
            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylistClients;
        }

        public static Stylist Find(int id)
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@searchId);";

        MySqlParameter searchid = new MySqlParameter();
        searchid.ParameterName = "@searchId";
        searchid.Value = id;
        cmd.Parameters.Add(searchid);

        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int StylistId = 0;
        string StylistName = "";
        string StylistDetails = "";

        while(rdr.Read())
        {
            StylistId = rdr.GetInt32(0);
            StylistName = rdr.GetString(1);
            StylistDetails = rdr.GetString(2);
        }
        Stylist newStylist = new Stylist(StylistName, StylistDetails, StylistId);
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return newStylist;

        }
    }
}
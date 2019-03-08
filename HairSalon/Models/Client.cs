using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Client
    {
        private string _clientName;
        private int _clientPhoneNumber;
        private string _clientNotes;
        private int _id;

        public Client(string clientName, int clientPhoneNumber, string clientNotes, int id = 0)
        {
            _clientName = clientName;
            _clientPhoneNumber = clientPhoneNumber;
            _clientNotes = clientNotes;
            _id = id;
        }

        public string GetName()
        {
            return _clientName;
        }

        public int GetPhoneNumber()
        {
            return _clientPhoneNumber;
        }

        public string GetNotes()
        {
            return _clientNotes;
        }

        public int GetId()
        {
            return _id;
        }

        public void SetName(string newName)
        {
            _clientName = newName;
        }

        public void SetPhoneNumber(int newPhoneNumber)
        {
            _clientPhoneNumber = newPhoneNumber;
        }

        public void SetNotes(string newNotes)
        {
            _clientNotes = newNotes;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                bool idEquality = this.GetId() == newClient.GetId();
                bool nameEquality = this.GetName() == newClient.GetName();
                bool phoneNumberEquality = this.GetPhoneNumber() == newClient.GetPhoneNumber();
                bool notesEquality = this.GetNotes() == newClient.GetNotes();
                return (idEquality && nameEquality && phoneNumberEquality && notesEquality);
            }
        }

        public static List<Client> GetAll() //adjust
        {
            List<Client> allClients = new List<Client> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int ClientId = rdr.GetInt32(0);
                string ClientName = rdr.GetString(1);
                int ClientPhoneNumber = rdr.GetInt32(2);
                string ClientNotes = rdr.GetString(3);
                Client newClient = new Client(ClientName, ClientPhoneNumber, ClientNotes, ClientId);
                allClients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allClients;
        }

        public void Save() //adjusted with new properties(client)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients (name, phone_number, notes) VALUES (@name, @phone_number, @notes);";
            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this._clientName;
            cmd.Parameters.Add(name);
            MySqlParameter phone_number = new MySqlParameter();
            phone_number.ParameterName = "@phone_number";
            phone_number.Value = this._clientPhoneNumber;
            cmd.Parameters.Add(phone_number);
            MySqlParameter notes = new MySqlParameter();
            notes.ParameterName = "@notes";
            notes.Value = this._clientNotes;
            cmd.Parameters.Add(notes);
            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Client Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE id = (@searchId);";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int clientId = 0;
            string clientName = "";
            int clientPhoneNumber = 0;
            string clientNotes = "";
            while(rdr.Read())
            {
                clientId = rdr.GetInt32(0);
                clientName = rdr.GetString(1);
                clientPhoneNumber = rdr.GetInt32(2);
                clientNotes = rdr.GetString(3);
            }
            Client newClient = new Client(clientName, clientPhoneNumber, clientNotes, clientId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newClient;
        }

        public void Delete(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients WHERE id = @searchId;";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);
            cmd.ExecuteNonQuery();
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
        //     cmd.CommandText = @"DELETE FROM stylists";
        //     cmd.ExecuteNonQuery();
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }

        // }


        public void Edit(string newName, int newPhoneNumber, string newNotes)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE clients SET name = @newName, phone_number = @newPhoneNumber, notes = @newNotes WHERE id = @searchId;";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = _id;
            cmd.Parameters.Add(searchId);
            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@newName";
            name.Value = newName;
            cmd.Parameters.Add(name);
            MySqlParameter phone_number = new MySqlParameter();
            phone_number.ParameterName = "@newPhoneNumber";
            phone_number.Value = newPhoneNumber;
            cmd.Parameters.Add(phone_number);
            MySqlParameter notes = new MySqlParameter();
            notes.ParameterName = "@newNotes";
            notes.Value = newNotes;
            cmd.Parameters.Add(notes);
            cmd.ExecuteNonQuery();
            _clientName = newName;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public List<Stylist> GetStylists() //test
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT stylists.* from clients
                JOIN stylists_clients ON (clients.id = stylists_clients.client_id)
                JOIN stylists ON (stylists_clients.stylist_id = stylists.id)
                WHERE clients.id = @ClientId;";
            MySqlParameter clientIdParameter = new MySqlParameter();
            clientIdParameter.ParameterName = "@ClientId";
            clientIdParameter.Value = _id;
            cmd.Parameters.Add(clientIdParameter);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<Stylist> stylists = new List<Stylist>{};
            while(rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                string stylistDetails = rdr.GetString(2);
                Stylist newStylist = new Stylist(stylistName, stylistDetails, stylistId);
                stylists.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return stylists;
        }

        public static void ClearJoinTable()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists_clients";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model.DataBase
{
    public class UserDataBase : DataBase
    {
        public UserDataBase() 
        {
            myConnection = new SQLiteConnection("Data Source=users.sqlite3");
            mutex = new Mutex();
        }

        public List<int> Login(string login, string password)
        {
            mutex.WaitOne();
            string hash_password = hash(password);
            string query = "SELECT typeId, id FROM users WHERE name = @login AND hash_password = @hash_password";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            OpenConnection();
            myCommand.Parameters.AddWithValue("@login", login);
            myCommand.Parameters.AddWithValue("@hash_password", hash_password);
            SQLiteDataReader reader = myCommand.ExecuteReader();
            List<int> data;
            if (reader.Read())
                data = new List<int>() { (int)reader.GetInt32(0), (int)reader.GetInt32(1) };
            else
                data = new List<int>() { 0, 0 };
            CloseConnection();
            mutex.ReleaseMutex();
            return data;
        }

        public DataTable UserList()
        {
            mutex.WaitOne();
            string query = "SELECT id, name, email, typeId FROM users";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            OpenConnection();
            myCommand.ExecuteNonQuery();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(myCommand);
            DataTable dt = new DataTable("users");
            adapter.Fill(dt);
            CloseConnection();
            mutex.ReleaseMutex();
            return dt;
        }

        public void Insert(string name, string email, string password, int typeId)
        {
            mutex.WaitOne();
            string query = "INSERT INTO users ('name', 'email', 'hash_password', 'typeId') VALUES (@name, @email, @hash_password, @typeId)";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            OpenConnection();
            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@email", email);
            myCommand.Parameters.AddWithValue("@hash_password", password);
            myCommand.Parameters.AddWithValue("@typeId", typeId);
            myCommand.ExecuteNonQuery();
            CloseConnection();
            mutex.ReleaseMutex();
        }
    }
}

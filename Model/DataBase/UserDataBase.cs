using System;
using System.Collections.Generic;
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
    }
}

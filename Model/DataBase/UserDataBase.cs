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

        private string hash(string password)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(password);
            MemoryStream stream = new MemoryStream(byteArray);
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(stream);
            return Encoding.UTF8.GetString(md5data);
        }

        public List<int> Login(string password, string login)
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

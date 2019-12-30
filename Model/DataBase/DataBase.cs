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
    public abstract class DataBase
    {
        protected SQLiteConnection myConnection;
        protected Mutex mutex;

        public DataBase()
        {
        }

        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }

        protected string hash(string password)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(password);
            MemoryStream stream = new MemoryStream(byteArray);
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(stream);
            return Encoding.UTF8.GetString(md5data);
        }
    }
}

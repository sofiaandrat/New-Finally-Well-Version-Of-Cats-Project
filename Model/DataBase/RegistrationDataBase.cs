using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model.DataBase
{
    public class RegistrationDataBase:DataBase
    {
        public RegistrationDataBase()
        {
            myConnection = new SQLiteConnection("Data Source=users.sqlite3");
            mutex = new Mutex();
        }

        public bool IsItFree(string name, string email)
        {
            mutex.WaitOne();
            string query1 = "SELECT name FROM users WHERE name = @name OR email = @email";
            SQLiteCommand myCommand = new SQLiteCommand(query1, this.myConnection);
            string query2 = "SELECT name FROM registration WHERE name = @name OR email = @email";
            SQLiteCommand myCommand1 = new SQLiteCommand(query2, this.myConnection);
            OpenConnection();
            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@email", email);
            myCommand1.Parameters.AddWithValue("@name", name);
            myCommand1.Parameters.AddWithValue("@email", email);
            SQLiteDataReader reader = myCommand.ExecuteReader();
            SQLiteDataReader reader1 = myCommand1.ExecuteReader();
            bool flag = true;
            if (!reader.Read() || !reader1.Read())
                flag = false;
            CloseConnection();
            mutex.ReleaseMutex();
            return flag;
        }
    }
}

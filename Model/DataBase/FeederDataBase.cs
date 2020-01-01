using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model.DataBase
{
    public class FeederDataBase:DataBase
    {
        public FeederDataBase()
        {
            myConnection = new SQLiteConnection("Data Source=users.sqlite3");
            mutex = new Mutex();
        }

        public DataTable FeedersList(int userId)
        {
            mutex.WaitOne();
            string query = "SELECT feederId, amount FROM feeder WHERE userId = @userId";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("@userId", userId);
            OpenConnection();
            myCommand.ExecuteNonQuery();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(myCommand);
            DataTable dt = new DataTable("feeders");
            adapter.Fill(dt);
            CloseConnection();
            mutex.ReleaseMutex();
            return dt;
        }
    }
}

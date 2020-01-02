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
    public class EventDataBase:DataBase
    {
        public EventDataBase()
        {
            myConnection = new SQLiteConnection("Data Source=users.sqlite3");
            mutex = new Mutex();
        }

        public DataTable EventsList(int scheduleId)
        {
            mutex.WaitOne();
            string query = "SELECT time, amount FROM evens WHERE scheduleId = @scheduleId";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("@scheduleId", scheduleId);
            OpenConnection();
            myCommand.ExecuteNonQuery();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(myCommand);
            DataTable dt = new DataTable("events");
            adapter.Fill(dt);
            CloseConnection();
            mutex.ReleaseMutex();
            return dt;
        }
    }
}

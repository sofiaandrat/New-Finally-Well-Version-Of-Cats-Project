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
    public class ScheduleDataBase:DataBase
    {
        public ScheduleDataBase()
        {
            mutex = new Mutex();
            myConnection = new SQLiteConnection("Data Source=users.sqlite3");
        }

        public DataTable UpdateScheduleList(int feederId)
        {
            mutex.WaitOne();
            string query = "SELECT SheduleId, Name FROM tags WHERE feederId = @feederId";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("@feederId", feederId);
            OpenConnection();
            myCommand.ExecuteNonQuery();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(myCommand);
            DataTable dt = new DataTable("schedule");
            adapter.Fill(dt);
            CloseConnection();
            mutex.ReleaseMutex();
            return dt;
        }
    }
}

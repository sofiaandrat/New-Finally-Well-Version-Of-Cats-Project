using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model.DataBase;

namespace Model
{
    public class User_sUpdateService:IUser_sUpdateService
    {
        private FeederDataBase feederDataBase;
        private TagsDataBase tagsDataBase;
        private ScheduleDataBase scheduleDataBase;
        private EventDataBase eventDataBase;

        DataTable lastVersionOfFeeders;
        DataTable lastVersionOfTags;
        DataTable lastVersionOfSchedule;
        DataTable lastVersionOfEvents;

        private int selectedUser;
        public int SelectedUser { get; set; }
        private int selectedFeeder;
        public int SelectedFeeder { get; set; }
        private int selectedSchedule;
        public int SelectedSchedule { get; set; }

        private Thread thread;

        public event Action FeedersListChanged;
        public event Action ScheduleListChanged;
        public event Action TagsListChanged;
        public event Action EventsListChanged;

        public User_sUpdateService(FeederDataBase feederDataBase, TagsDataBase tagsDataBase, ScheduleDataBase scheduleDataBase, EventDataBase eventDataBase)
        {
            this.feederDataBase = feederDataBase;
            this.tagsDataBase = tagsDataBase;
            this.scheduleDataBase = scheduleDataBase;
            this.eventDataBase = eventDataBase;

            lastVersionOfEvents = null;
            lastVersionOfFeeders = null;
            lastVersionOfSchedule = null;
            lastVersionOfTags = null;

            SelectedUser = 0;
            SelectedFeeder = 0;
            SelectedSchedule = 0;

            thread = new Thread(CheckUpdate);
        }

        private void CheckUpdate()
        {
            while (true)
            {
                if (!AreTablesTheSame(feederDataBase.FeedersList(SelectedFeeder), lastVersionOfFeeders))
                {
                    lastVersionOfFeeders = feederDataBase.FeedersList(SelectedFeeder);
                    FeedersListChanged?.Invoke();
                }

                if(!AreTablesTheSame(scheduleDataBase.UpdateScheduleList(SelectedFeeder), lastVersionOfSchedule))
                {
                    lastVersionOfSchedule = scheduleDataBase.UpdateScheduleList(SelectedFeeder);
                    ScheduleListChanged?.Invoke();
                }

                if(!AreTablesTheSame(tagsDataBase.UpdateTagsList(SelectedFeeder), lastVersionOfTags))
                {
                    lastVersionOfTags = tagsDataBase.UpdateTagsList(SelectedFeeder);
                    TagsListChanged?.Invoke();
                }

                if(!AreTablesTheSame(eventDataBase.EventsList(SelectedSchedule), lastVersionOfSchedule))
                {
                    lastVersionOfSchedule = eventDataBase.EventsList(SelectedSchedule);
                    EventsListChanged?.Invoke();
                }
                Thread.Sleep(2000);
            }
        }

        public DataTable AskFeedersList() => lastVersionOfFeeders;
        public DataTable AskTagsList() => lastVersionOfTags;
        public DataTable AskShedulesList() => lastVersionOfSchedule;
        public DataTable AskEventsList() => lastVersionOfEvents;

        public static bool AreTablesTheSame(DataTable tbl1, DataTable tbl2) //from stackoverflow
        {
            if (tbl1 == null && tbl2 == null)
                return true;
            if (tbl1 == null || tbl2 == null)
                return false;
            if (tbl1.Rows.Count != tbl2.Rows.Count || tbl1.Columns.Count != tbl2.Columns.Count)
                return false;


            for (int i = 0; i < tbl1.Rows.Count; i++)
            {
                for (int c = 0; c < tbl1.Columns.Count; c++)
                {
                    if (!Equals(tbl1.Rows[i][c], tbl2.Rows[i][c]))
                        return false;
                }
            }
            return true;
        }

        public void ChangeSelectedUser(int id)
        {
            SelectedUser = id;
        }

        public void ChangeSelectedFeeder(int feederId)
        {
            SelectedFeeder = feederId;
        }

        public void ChangeSelectedSchedule(int scheduleId)
        {
            SelectedSchedule = scheduleId;
        }
    }
}

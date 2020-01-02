using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IUser_sUpdateService
    {
        event Action FeedersListChanged;
        event Action ScheduleListChanged;
        event Action TagsListChanged;
        event Action EventsListChanged;

        DataTable AskFeedersList();
        DataTable AskTagsList();
        DataTable AskShedulesList();
        DataTable AskEventsList();

        void ChangeSelectedUser(int id);
        void ChangeSelectedFeeder(int feederId);
        void ChangeSelectedSchedule(int scheduleId);
    }
}

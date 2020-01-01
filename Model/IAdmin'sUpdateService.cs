using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IAdmin_sUpdateService
    {
        event Action RegistrationQueueChange;
        event Action UsersListChange;
        event Action FeedersListChange;
        event Action TagsListChange;
        DataTable AskRegistrationQueue();
        DataTable AskUsersList();
        DataTable AskFeedersList();
        DataTable AskTagsList();
        void ChangeSelectedFeeder(int feederId);
        void ChangeSelectedUser(int userId);
    }
}

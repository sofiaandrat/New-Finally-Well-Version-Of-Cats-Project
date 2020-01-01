using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public interface IAdminView:IUserProfilerView
    {
        void ShowRegistrationQueue(DataTable dataTable);
        void ShowUsersList(DataTable dataTable);
        void ShowFeedersList(DataTable dataTable);
        void ShowTagsLists(DataTable dataTable);

        event Action selectedFeederWasChanged;
        event Action selectedUserWasChanged;
        event Action AskRegistration;
    }
}

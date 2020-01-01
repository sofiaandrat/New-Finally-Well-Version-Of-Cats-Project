using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Presenter
{
    public interface IUserProfilerView:IView
    {
        void UpdateTable(DataTable dataTable, DataGrid dataGrid);
        object AskLastSender();
    }
}

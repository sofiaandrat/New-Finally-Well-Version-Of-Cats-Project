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
        DataTable AskRegistrationQueue();
       // void StartUpdate();
    }
}

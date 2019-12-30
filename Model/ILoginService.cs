using Model.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface ILoginService
    {
        void CheckLogin(string name, string password);
        event Action WrongLoginData;
        event Action LoginWasSuccesful;
        UserProfiler GiveUserInformation();
    }
}

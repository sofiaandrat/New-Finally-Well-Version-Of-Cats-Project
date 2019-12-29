using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public interface IMainView
    {
        event Action PushRegistration;
        event Action PushLogin;
        string GetName();
        string GetPassword();
        void ShowWrongLoginData();
        void HideWrongLoginData();
    }
}

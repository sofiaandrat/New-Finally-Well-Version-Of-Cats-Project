using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public interface IRegistrationView:IView
    {
        event Action PushRegistration;
        string GetEmail();
        string GetPassword();
        string GetLogin();
        void ShowWrongLoginLabel();
    }
}

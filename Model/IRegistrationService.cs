using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IRegistrationService
    {
        event Action UserCantBeRegister;
        void CheckRegistration(string name, string email, string password);
    }
}

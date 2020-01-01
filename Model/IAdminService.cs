using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IAdminService
    {
        void AskRegistration(string name, string email, string hash_password, int typeId);
        void ConfirmRegistration();

        event Action RegistrationView;
    }
}

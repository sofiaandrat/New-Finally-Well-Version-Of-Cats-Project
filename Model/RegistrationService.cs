using Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RegistrationService:IRegistrationService
    {
        private event Action UserCantBeRegister;
        public RegistrationService() { }
        public void CheckRegistration()
        {
            RegistrationDataBase registrationDataBase = new RegistrationDataBase();
           /* if (!registrationDataBase.IsItFree(name, email))
                UserCantBeRegister?.Invoke();*/
        }
    }
}

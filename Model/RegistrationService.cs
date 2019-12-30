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
        public event Action UserCantBeRegister;
        private RegistrationDataBase registrationDataBase = new RegistrationDataBase();
        public RegistrationService() 
        {
            this.registrationDataBase = new RegistrationDataBase();
        }
        public void CheckRegistration(string name, string email, string password)
        {
            if (registrationDataBase.IsItFree(name, email))
                registrationDataBase.Insert(name, email, password);
            else
                UserCantBeRegister?.Invoke();
        }
    }
}

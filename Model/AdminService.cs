using Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AdminService:IAdminService
    {
        private string regName;
        private string regEmail;
        private string regHash_password;
        private int regTypeId;
        public event Action RegistrationView;
        public AdminService()
        { }
        public void AskRegistration(string name, string email, string hash_password, int typeId)
        {
            regName = name;
            regEmail = email;
            regHash_password = hash_password;
            regTypeId = typeId;
            RegistrationView?.Invoke();
        }

        public void ConfirmRegistration()
        {
            UserDataBase usersDataBase = new UserDataBase();
            usersDataBase.Insert(regName, regEmail, regHash_password, regTypeId);
            RegistrationDataBase registrationDataBase = new RegistrationDataBase();
            registrationDataBase.Delete(regName);

        }
    }
}

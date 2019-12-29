using Model.DataBase;
using Model.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LoginService:ILoginService
    {
        private UserDataBase userDataBase;
        //private event Action OpenUserProfiler;
        public event Action WrongLoginData;
        public event Action LoginWasSuccesful;
        public LoginService(UserDataBase userDataBase)
        {
            this.userDataBase = userDataBase;
        }

        public void CheckLogin(string name, string password)
        {
            List <int> loginRequest = userDataBase.Login(name, password);
            if(loginRequest[0] == 0)
            {
                WrongLoginData?.Invoke();
            } else
            {
                UserProfiler userProfiler = new UserProfiler(loginRequest[0], loginRequest[1]);
                userProfiler.IWasBorn += UserWasOpen;
            }
        }

        public void UserWasOpen()
        {
            LoginWasSuccesful?.Invoke();
        }
    }
}

using Model.DataBase;
using Model.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Threading;

namespace Model
{
    public class LoginService:ILoginService
    {
        private UserDataBase userDataBase;
        public event Action WrongLoginData;
        public event Action LoginWasSuccesful;
        private UserProfiler userProfiler;
        public LoginService(UserDataBase userDataBase)
        {
            this.userDataBase = userDataBase;
            userProfiler = null;
        }

        public void CheckLogin(string name, string password)
        {
            List <int> loginRequest = userDataBase.Login(name, password);
            if(loginRequest[0] == 0)
            {
                WrongLoginData?.Invoke();
            } else
            {
                userProfiler = new UserProfiler(loginRequest[0], loginRequest[1]);
                UserWasOpen();
            }
        }

        public void UserWasOpen()
        {
            LoginWasSuccesful?.Invoke();
        }

        public UserProfiler GiveUserInformation() => userProfiler;
    }
}

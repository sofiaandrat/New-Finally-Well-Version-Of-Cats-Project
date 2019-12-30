using Model.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class Admin_sUpdateService:IAdmin_sUpdateService
    {
        private RegistrationDataBase registrationDataBase;
        private DataTable lastVersionRegistrationQueue;
        private Thread checkUpdate;
        public event Action RegistrationQueueChange;

        public Admin_sUpdateService(RegistrationDataBase registrationDataBase)
        {
            this.registrationDataBase = registrationDataBase;
            checkUpdate = new Thread(CheckUpdate);
            lastVersionRegistrationQueue = null;
            checkUpdate.Start();
        }

        private void CheckUpdate()
        {
            if(registrationDataBase.RegistrationList() != lastVersionRegistrationQueue)
            {
                lastVersionRegistrationQueue = registrationDataBase.RegistrationList();
                RegistrationQueueChange?.Invoke();
            }
            Thread.Sleep(2000);
        }

        public DataTable AskRegistrationQueue() => lastVersionRegistrationQueue;
    }
}

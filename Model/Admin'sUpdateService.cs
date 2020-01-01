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
        private UserDataBase userDataBase;
        private FeederDataBase feederDataBase;
        private TagsDataBase tagsDataBase;

        private DataTable lastVersionRegistrationQueue;
        private DataTable lastVersionUsersList;
        private DataTable lastVersionFeederList;
        private DataTable lastVersionTagsList;

        private Thread checkUpdate;

        private int selectedUserId;
        public int SelectedUserId
        {
            set { selectedUserId = value; }
        }
        private int selectedFeederId;
        public int SelectedFeederId
        {
            set { selectedFeederId = value; }
        }

        public event Action RegistrationQueueChange;
        public event Action UsersListChange;
        public event Action FeedersListChange;
        public event Action TagsListChange;

        public Admin_sUpdateService(RegistrationDataBase registrationDataBase, UserDataBase userDataBase, FeederDataBase feederDataBase, TagsDataBase tagsDataBase)
        {
            this.registrationDataBase = registrationDataBase;
            this.userDataBase = userDataBase;
            this.feederDataBase = feederDataBase;
            this.tagsDataBase = tagsDataBase;

            checkUpdate = new Thread(CheckUpdate);
            lastVersionRegistrationQueue = null;
            lastVersionUsersList = null;
            lastVersionFeederList = null;
            lastVersionTagsList = null;
            selectedFeederId = 0;
            selectedUserId = 0;
            checkUpdate.Start();
        }

        private void CheckUpdate()
        {
            while(true)
            {
                if (!AreTablesTheSame(registrationDataBase.RegistrationList(), lastVersionRegistrationQueue))
                {
                    lastVersionRegistrationQueue = registrationDataBase.RegistrationList();
                    RegistrationQueueChange?.Invoke();
                }

                if (!AreTablesTheSame(userDataBase.UserList(), lastVersionUsersList))
                {
                    lastVersionUsersList = userDataBase.UserList();
                    UsersListChange?.Invoke();
                }

                if (!AreTablesTheSame(feederDataBase.FeedersList(selectedUserId), lastVersionFeederList))
                {
                    lastVersionFeederList = feederDataBase.FeedersList(selectedUserId);
                    FeedersListChange?.Invoke();
                }

                if (!AreTablesTheSame(tagsDataBase.UpdateTagsList(selectedFeederId), lastVersionTagsList))
                {
                    lastVersionTagsList = tagsDataBase.UpdateTagsList(selectedFeederId);
                    TagsListChange?.Invoke();
                }
                Thread.Sleep(2000);
            }
        }

        public void ChangeSelectedFeeder(int feederId)
        {
            SelectedFeederId = feederId;
        }

        public void ChangeSelectedUser(int userId)
        {
            SelectedUserId = userId;
        }

        public DataTable AskRegistrationQueue() => lastVersionRegistrationQueue;
        public DataTable AskUsersList() => lastVersionUsersList;
        public DataTable AskFeedersList() => lastVersionFeederList;
        public DataTable AskTagsList() => lastVersionTagsList;

        public static bool AreTablesTheSame(DataTable tbl1, DataTable tbl2) //from stackoverflow
        {
            if (tbl1 == null && tbl2 == null)
                return true;
            if (tbl1 == null || tbl2 == null)
                return false;
            if (tbl1.Rows.Count != tbl2.Rows.Count || tbl1.Columns.Count != tbl2.Columns.Count)
                return false;


            for (int i = 0; i < tbl1.Rows.Count; i++)
            {
                for (int c = 0; c < tbl1.Columns.Count; c++)
                {
                    if (!Equals(tbl1.Rows[i][c], tbl2.Rows[i][c]))
                        return false;
                }
            }
            return true;
        }
    }
}

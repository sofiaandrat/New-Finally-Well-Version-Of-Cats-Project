using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Windows.Controls;

namespace Presenter
{
    public class AdminPresenter
    {
        private readonly IKernel kernel;
        private readonly IAdminView view;
        private readonly IAdmin_sUpdateService admin_SUpdateService;
        private readonly IAdminService adminService;

        public AdminPresenter(IKernel kernel, IAdminView view, IAdmin_sUpdateService admin_SUpdateService, IAdminService adminService)
        {
            this.kernel = kernel;
            this.view = view;
            this.admin_SUpdateService = admin_SUpdateService;
            this.adminService = adminService;

            this.admin_SUpdateService.RegistrationQueueChange += ShowRegistrationQueue;
            this.admin_SUpdateService.UsersListChange += ShowUsersList;
            this.admin_SUpdateService.FeedersListChange += ShowFeederList;
            this.admin_SUpdateService.TagsListChange += ShowTagsList;

            this.view.selectedFeederWasChanged += SelectedFeederWasChanged;
            this.view.selectedUserWasChanged += SelectedUserWasChanged;
            this.view.AskRegistration += AskRegistration;

            this.adminService.RegistrationView += RegistrationView;


            view.Show();
        }

        public void ShowRegistrationQueue()
        {
            view.ShowRegistrationQueue(admin_SUpdateService.AskRegistrationQueue());
        }

        public void ShowUsersList()
        {
            view.ShowUsersList(admin_SUpdateService.AskUsersList());
        }

        public void ShowFeederList()
        {
            view.ShowFeedersList(admin_SUpdateService.AskFeedersList());
        }

        public void ShowTagsList()
        {
            view.ShowTagsLists(admin_SUpdateService.AskTagsList());
        }

        public void SelectedUserWasChanged()
        {
            object sender = view.AskLastSender();
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            DataTable Tags = new DataTable();
            int SelectedUser = 0;
            if (row_selected != null)
            {
                SelectedUser = Convert.ToInt32(row_selected["id"].ToString());
            }
            admin_SUpdateService.ChangeSelectedUser(SelectedUser);
        }

        public void SelectedFeederWasChanged()
        {
            object sender = view.AskLastSender();
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            DataTable Tags = new DataTable();
            int SelectedFeeder = 0;
            if (row_selected != null)
            {
                SelectedFeeder = Convert.ToInt32(row_selected["feederId"].ToString());
            }
            admin_SUpdateService.ChangeSelectedFeeder(SelectedFeeder);
        }

        public void AskRegistration()
        {
            object sender = view.AskLastSender();
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                string login = row_selected["name"].ToString();
                string email = row_selected["email"].ToString();
                string hash_password = row_selected["hash_password"].ToString();
                int typeId = Convert.ToInt32(row_selected["typeId"].ToString());
                adminService.AskRegistration(login, email, hash_password, typeId);
            }
        }

        public void RegistrationView()
        {
            AccessRegistrationPresenter accessRegistrationPresenter = new AccessRegistrationPresenter(kernel, kernel.Get<IAccessRegistration>(), adminService);
        }
    }
}

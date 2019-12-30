using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Presenter
{
    public class AdminPresenter
    {
        private readonly IKernel kernel;
        private readonly IAdminView view;
        private readonly IAdmin_sUpdateService admin_SUpdateService;

        public AdminPresenter(IKernel kernel, IAdminView view, IAdmin_sUpdateService admin_SUpdateService)
        {
            this.kernel = kernel;
            this.view = view;
            this.admin_SUpdateService = admin_SUpdateService;

            this.admin_SUpdateService.RegistrationQueueChange += ShowRegistrationQueue;

            view.Show();
            //admin_SUpdateService.StartUpdate();
        }

        public void ShowRegistrationQueue()
        {
            view.ShowRegistrationQueue(admin_SUpdateService.AskRegistrationQueue());
        }

    }
}

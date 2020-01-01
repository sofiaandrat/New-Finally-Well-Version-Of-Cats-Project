using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Presenter
{
    public class AccessRegistrationPresenter
    {
        private readonly IKernel kernel;
        private readonly IAccessRegistration view;
        private readonly IAdminService service;

        public AccessRegistrationPresenter(IKernel kernel, IAccessRegistration view, IAdminService service)
        {
            this.kernel = kernel;
            this.view = view;
            this.service = service;

            this.view.Registration += service.ConfirmRegistration;

            view.Show();
        }

    }
}

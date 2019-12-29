using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Presenter
{
    public class RegistrationPresenter
    {
        private readonly IKernel kernel;
        private readonly IRegistrationView view;
        private readonly IRegistrationService service;
        public RegistrationPresenter(IKernel kernel, IRegistrationView view, IRegistrationService service)
        {
            this.kernel = kernel;
            this.view = view;
            this.service = service;
           // this.view.PushRegistration += PushRegistration;
        }

        private void PushRegistration()
        {
            
        }
    }
}

using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Elements;

namespace Presenter
{
    public class MainPresenter
    {
        private readonly IKernel kernel;
        private readonly IMainView view;
        private readonly ILoginService service;
        public MainPresenter(IKernel kernel, IMainView view, ILoginService service) 
        {
            this.kernel = kernel;
           // kernel.Bind<ILoginService>().To<LoginService>();
            kernel.Bind<IRegistrationService>().To<RegistrationService>();
            kernel.Bind<IUserProfiler>().To<UserProfiler>();

            this.view = view;
            this.service = service;
            this.view.PushRegistration += PushRegistration;
            this.view.PushLogin += CheckLogin;
            this.service.WrongLoginData += DrawWrongLogin;
            this.service.LoginWasSuccesful += createUserProfiler;
        }

        private void PushRegistration()
        {
            RegistrationPresenter registrationPresenter = new RegistrationPresenter(kernel, kernel.Get<IRegistrationView>(), kernel.Get<IRegistrationService>());
            
            //var registrationView = kernel.Get<IRegistrationView>();
           // registrationView.Show();
        }

        private void CheckLogin()
        {
            view.HideWrongLoginData();
            service.CheckLogin(view.GetName(), view.GetPassword());
        }

        private void DrawWrongLogin()
        {
            view.ShowWrongLoginData();
        }

        private void createUserProfiler()
        {
            UserProfilerPresenter userProfilerPresenter = new UserProfilerPresenter(kernel, service.GiveUserInformation());
        }
    }
}

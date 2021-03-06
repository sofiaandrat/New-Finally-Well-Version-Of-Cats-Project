﻿using Ninject;
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
            this.view.Show();
            this.view.PushRegistration += PushRegistration;
            this.service.UserCantBeRegister += WrongRegisterData;
        }

        private void PushRegistration()
        {
            service.CheckRegistration(view.GetLogin(), view.GetEmail(), view.GetPassword());
        }

        private void WrongRegisterData()
        {
            view.ShowWrongLoginLabel();
        }
    }
}

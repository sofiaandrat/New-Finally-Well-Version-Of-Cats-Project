using Model.Elements;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Presenter
{
    public class UserProfilerPresenter
    {
        private readonly IKernel kernel;
        private readonly IUserProfilerView view;
        public UserProfilerPresenter(IKernel kernel, UserProfiler userProfiler)
        {
            this.kernel = kernel;

            kernel.Bind<IAdmin_sUpdateService>().To<Admin_sUpdateService>();

            switch(userProfiler.TypeId)
            {
                case 1:
                    view = kernel.Get<IUserView>();
                    break;
                case 2:
                    AdminPresenter adminPresenter = new AdminPresenter(kernel, kernel.Get<IAdminView>(), kernel.Get<IAdmin_sUpdateService>());
                    break;
                case 3:
                    view = kernel.Get<ITesterView>();
                    break;
            }
        }
    }
}

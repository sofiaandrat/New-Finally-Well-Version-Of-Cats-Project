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
            kernel.Bind<IAdminService>().To<AdminService>();
            kernel.Bind<IUser_sUpdateService>().To<User_sUpdateService>();

            switch(userProfiler.TypeId)
            {
                case 1:
                    UserPresenter userPresenter = new UserPresenter(kernel, kernel.Get<IUserView>(), kernel.Get<IUser_sUpdateService>(),userProfiler);
                    break;
                case 2:
                    AdminPresenter adminPresenter = new AdminPresenter(kernel, kernel.Get<IAdminView>(), kernel.Get<IAdmin_sUpdateService>(), kernel.Get<IAdminService>());
                    break;
                case 3:
                    view = kernel.Get<ITesterView>();
                    break;
            }
        }
    }
}

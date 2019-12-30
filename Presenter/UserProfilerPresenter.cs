using Model.Elements;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public class UserProfilerPresenter
    {
        private readonly IKernel kernel;
        private readonly IUserProfilerView view;
        public UserProfilerPresenter(IKernel kernel, UserProfiler userProfiler)
        {
            this.kernel = kernel;
            switch(userProfiler.TypeId)
            {
                case 1:
                    view = kernel.Get<IUserView>();
                    break;
                case 2:
                    view = kernel.Get<IAdminView>();
                    break;
                case 3:
                    view = kernel.Get<ITesterView>();
                    break;
            }
            view.Show();
        }
    }
}

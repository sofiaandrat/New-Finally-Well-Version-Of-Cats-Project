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
    public class UserPresenter
    {
        private readonly IKernel kernel;
        private readonly IUserView view;
        private readonly IUser_sUpdateService user_SUpdateService;
        private UserProfiler userProfiler;
        public  UserPresenter(IKernel kernel, IUserView view, IUser_sUpdateService user_SUpdateService, UserProfiler userProfiler)
        {
            this.kernel = kernel;
            this.view = view;
            this.userProfiler = userProfiler;
            this.user_SUpdateService = user_SUpdateService;
            this.user_SUpdateService.ChangeSelectedUser(userProfiler.Id);

            view.Show();
        }

    }
}

using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Presenter;
using Model;

namespace CatsBeautifulVersion
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainView, IView
    {
        public event Action PushRegistration;
        public event Action PushLogin;
        private readonly StandardKernel kernel;
        public MainWindow()
        {
            InitializeComponent();
            kernel = new StandardKernel();
            kernel.Bind<IRegistrationView>().To<Registration>();
            kernel.Bind<ILoginService>().To<LoginService>();
            kernel.Bind<ITesterView>().To<TesterView>();
            kernel.Bind<IUserView>().To<UserView>();
            kernel.Bind<IAdminView>().To<AdminView>();
            kernel.Bind<IAccessRegistration>().To<AccessRegistration>();
            MainPresenter mainPresenter = new MainPresenter(kernel, this, kernel.Get<ILoginService>());
        }
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            PushRegistration?.Invoke();
        }

        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            PushLogin?.Invoke();
        }

        public string GetName()
        {
            return Login.Text;
        }

        public string GetPassword()
        {
            return PasswordBox.Password;
        }

        public void ShowWrongLoginData()
        {
            Wrong_entrance.Visibility = Visibility.Visible;
        }

        public void HideWrongLoginData()
        {
            Wrong_entrance.Visibility = Visibility.Hidden;
        }
    }
}

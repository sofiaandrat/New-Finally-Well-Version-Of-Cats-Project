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
using System.Windows.Shapes;
using Presenter;

namespace CatsBeautifulVersion
{
    /// <summary>
    /// Логика взаимодействия для AdminView.xaml
    /// </summary>
    public partial class AdminView : Window, IAdminView, IUserProfilerView, IView
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void Feeders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Registration_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

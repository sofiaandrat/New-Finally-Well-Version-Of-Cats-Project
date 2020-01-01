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
    /// Логика взаимодействия для AccessRegistration.xaml
    /// </summary>
    public partial class AccessRegistration : Window, IAccessRegistration, IView
    {
        public event Action Registration;
        public AccessRegistration()
        {
            InitializeComponent();
        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Access_Click(object sender, RoutedEventArgs e)
        {
            Registration?.Invoke();
        }
    }
}

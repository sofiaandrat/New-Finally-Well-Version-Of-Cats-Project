using System;
using System.Collections.Generic;
using System.Data;
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
        private object lastSender;

        public event Action selectedFeederWasChanged;
        public event Action selectedUserWasChanged;
        public event Action AskRegistration;

        public AdminView()
        {
            InitializeComponent();
        }

        private void Feeders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lastSender = sender;
            selectedFeederWasChanged?.Invoke();
        }

        private void Registration_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lastSender = sender;
            AskRegistration?.Invoke();
        }

        private void Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lastSender = sender;
            selectedUserWasChanged?.Invoke();
        }

        public void ShowRegistrationQueue(DataTable registrationQueue)
        {
            UpdateTable(registrationQueue, Registration);
        }

        public void ShowUsersList(DataTable usersList)
        {
            UpdateTable(usersList, Users);
        }

        public void ShowFeedersList(DataTable feedersList)
        {
            UpdateTable(feedersList, Feeders);
        }

        public void ShowTagsLists(DataTable tagsList)
        {
            UpdateTable(tagsList, tags);
        }

        public void UpdateTable(DataTable dataTable, DataGrid dataGrid)
        {
            dataGrid.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                dataGrid.ItemsSource = dataTable.DefaultView;
            }));
        }

        public object AskLastSender() => lastSender;
    }
}

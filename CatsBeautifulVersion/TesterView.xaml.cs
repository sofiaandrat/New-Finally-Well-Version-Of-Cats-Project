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
    /// Логика взаимодействия для TesterView.xaml
    /// </summary>
    public partial class TesterView : Window, ITesterView, IView, IUserProfilerView
    {
        public TesterView()
        {
            InitializeComponent();
        }
    }
}

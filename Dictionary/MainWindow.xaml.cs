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

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("LoginPage.xaml", UriKind.Relative));
            HideMainWindowContent();
            DisableNavigation();
        }
        private void HideMainWindowContent()
        {
            mainContentPanel.Visibility = Visibility.Collapsed;
        }
        private void DisableNavigation()
        {
            mainFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
    }
}

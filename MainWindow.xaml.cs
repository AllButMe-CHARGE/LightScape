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
using LightScape;

namespace LightScape
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new DashboardView();
        }

        private void Settings_Click(object sender, MouseButtonEventArgs e)
        {
            MainContent.Content = new SettingsView();
        }

        private void About_Click(object sender, MouseButtonEventArgs e)
        {
            MainContent.Content = new AboutView();
        }

        private void Main_Click(object sender, MouseButtonEventArgs e)
        {
            MainContent.Content = new DashboardView();
        }

    }
}

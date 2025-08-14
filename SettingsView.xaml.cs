using LightScape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LightScape
{
    public partial class SettingsView : UserControl
    {
        private bool _isInitializing = false;

        public SettingsView()
        {
            InitializeComponent();
            _isInitializing = true; // Schutz vor zusätzlichen Popups (z.B. "Ed Modus activated!") aktiv (unterdrückt)

            EdToggleButton.IsChecked = AppSettings.EdModeEnabled; // Beispiel: Setze den Toggle-Zustand basierend auf AppSettings

            _isInitializing = false; // Schutz aus
        }

        public void Toggle_EdMode_Checked(object sender, RoutedEventArgs e)
        {
            if (_isInitializing) return;
            AppSettings.EdModeEnabled = true;
            MessageBox.Show("Ed Modus activated!");
            // TODO: Ed Modus aktivieren
        }

        public void Toggle_EdMode_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_isInitializing) return;
            AppSettings.EdModeEnabled = false;
            MessageBox.Show("Ed Mode deactivated!");
            // TODO: Ed Modus deaktivieren
        }
    }
}


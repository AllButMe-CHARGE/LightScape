using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Globalization;
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
    public partial class AboutView : UserControl
    {
        public AboutView()
        {
            InitializeComponent();

            // Ermittelt das echte Build-Datum der aktuell laufenden Assembly/EXE
            var exePath = Assembly.GetExecutingAssembly().Location;
            var buildDate = File.GetLastWriteTime(exePath);

            // Englisches Datumsformat (z. B. "August 13, 2025"), unabhängig von Windows-Sprache
            BuildDateRun.Text = buildDate.ToString("MMMM dd, yyyy", CultureInfo.InvariantCulture);
        }

        // Event-Handler für klickbare Links (Hyperlinks) in der About-Seite
        // Wird automatisch aufgerufen, wenn der Nutzer auf einen Hyperlink klickt,
        // der das Event "RequestNavigate" nutzt.
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // Öffnet die angegebene URL (e.Uri.AbsoluteUri) im Standardbrowser des Systems.
            // UseShellExecute = true → notwendig, damit Windows den Standardbrowser verwendet
            // statt zu versuchen, die URL direkt als Datei zu öffnen.
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });

            // Markiert das Event als "bearbeitet", damit WPF nicht versucht,
            // noch eine Standard-Navigation (die evtl. fehlschlägt) auszuführen.
            e.Handled = true;
        }

        private void OpenPdfLicense(object sender, RoutedEventArgs e)
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string pdf = System.IO.Path.Combine(exeDirectory, "Assets", "LightScape_License.pdf");

            if (File.Exists(pdf))
            {
              Process.Start(new ProcessStartInfo(pdf) { UseShellExecute= true });
            }

            else
            { MessageBox.Show("The lincense file could not be found.", "File missing", MessageBoxButton.OK, MessageBoxImage.Error); };
        }

    }
}

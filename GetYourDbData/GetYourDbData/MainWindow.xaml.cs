using System.Windows;
using Microsoft.Win32;
using System.IO;

namespace GetYourDbData
{
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            dbNameTextBox.Focus();
        }
        private void CopySqlScript(object sender, RoutedEventArgs e) {
            // Kopiert das SQL-Skript in die Zwischenablage, sofern es ein Skript gibt.
            if (sqlOutput.Text != "") Clipboard.SetText(sqlOutput.Text);
        }

        // Ermöglicht das Auswählen des Speicherorts und Speichern.
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "*.sql|sql";
            dlg.Title = "sqlQuerySpeichern";
            if (dlg.ShowDialog() == true)
            {
                File.WriteAllText(dlg.FileName, sqlOutput.Text);
            }
        }
    }
}

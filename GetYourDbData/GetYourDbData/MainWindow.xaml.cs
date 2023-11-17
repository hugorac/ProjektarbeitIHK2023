using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GetYourDbData {
    public partial class MainWindow : Window {
        public ObservableCollection<string> EnteredTableNames { get; set; }

        public MainWindow() {
            InitializeComponent();
            DataContext = this;

            EnteredTableNames = new ObservableCollection<string>();
        }

        private void tableNameTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Enter) {
                string newEntry = tableNameTextBox.Text.Trim();
                if (!string.IsNullOrWhiteSpace(newEntry) && !EnteredTableNames.Contains(newEntry)) {
                    EnteredTableNames.Add(newEntry);
                    tableNameListBox.Visibility = Visibility.Visible;
                }

                tableNameTextBox.Text = "";
                tableNameListBox.ItemsSource = EnteredTableNames;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            tableNameTextBox.Focus();
        }
        private void CopyConString(object sender, RoutedEventArgs e) {
            string textToCopy = "Hello, this text will be copied to the clipboard!";
            Clipboard.SetText(textToCopy);
        }
    }
}

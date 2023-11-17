using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GetYourDbData;

namespace GetYourDbData {
    public partial class MainWindow : Window {
        public ObservableCollection<string> EnteredTableNames { get; set; }
        public List<string> EnteredTableNamesList = new List<string>(); 
        
        public MainWindow() {
            InitializeComponent();
            DataContext = this;
            EnteredTableNames = new ObservableCollection<string>();

            Closing += MainWindow_Closing;
        }
        //This event will be triggered when closing the app
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            LocalDbController controller = new LocalDbController();
            controller.RenameDbToDeafault();
        }
        private void tableNameTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                string newEntry = tableNameTextBox.Text.Trim();
                if (!string.IsNullOrWhiteSpace(newEntry) && !EnteredTableNames.Contains(newEntry))
                {
                    EnteredTableNames.Add(newEntry);
                    tableNameListBox.Visibility = Visibility.Visible;
                }
                //Adds entry to list
                EnteredTableNamesList.Add(newEntry);

                tableNameTextBox.Text = "";
                tableNameListBox.ItemsSource = EnteredTableNames;
            }
        }

        //Copy the connection string to clipboard
        private void CopyConString(object sender, RoutedEventArgs e) {
            LocalDbController controller = new LocalDbController();
            Clipboard.SetText(controller.GetConString());
        }

        private void GetClick(object sender, RoutedEventArgs e) { 
            LocalDbController controller = new LocalDbController();
            ApiRequester requester = new ApiRequester();

            try {
                controller.UpdateDb(requester.GetSqlScript(dbNameTextBox.Text, EnteredTableNamesList).Result);
            }
            catch (System.Exception ex) {

                throw ex.InnerException;
            }
        }
    }
}

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace GetYourDbData
{
    public class SqlViewModel : INotifyPropertyChanged
    {
        // Konstruktor für die SqlViewModel.
        // Im Konstruktor werden die Properties initialisiert.
        public SqlViewModel() {
            GetDataCommand = new ActionCommand(model => GetSqlScript(), model => TableNames.Any());
            
            FillTableNamesListCommand = new ActionCommand(model => FillTableNamesList(), model => 
            {
                if (!string.IsNullOrWhiteSpace(model.TableName) && !TableNames.Contains(model.TableName))
                    return true;
                return false;

            });
            TableNames = new ObservableCollection<string>();
            DeleteTableNamesEntryCommand = new ActionCommand(model => DeleteTableNamesEntry(), model => true);

        }
        private string sqlResult;
        private string tableName;
        // Eigenschaften der Klasse
        public string Title { get; set; }
        public string DatabaseName { get; set; }
        public string TableName
        {
            get => tableName;
            set
            {
                if (value != tableName)
                {
                    tableName = value?.ToUpper();
                    NotifyPropertyChanged(nameof(TableName));
                }

            }
        }
        public ObservableCollection<string> TableNames { get; set; }
        public string SqlResult
        {
            get => sqlResult;
            set
            {
                if (value != sqlResult)
                {
                    sqlResult = value;
                    NotifyPropertyChanged(nameof(SqlResult));
                }

            }

        }
        public string SelectedTable { get; set; }
        public ActionCommand GetDataCommand { get; set; }
        public ICommand FillTableNamesListCommand { get; set; }
        public ICommand DeleteTableNamesEntryCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        // Das Ziel dieser Methode ist es, Benachrichtigungen über Änderungen von Eigenschaften zu senden,
        // wenn sich der Wert einer Eigenschaft ändert.
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        // Die Methode 
        public void GetSqlScript()
        {
            SqlApiServiceClient sqlApiServiceClient = new SqlApiServiceClient();
            SqlResult = sqlApiServiceClient.GetSqlScript(DatabaseName, TableNames).Result;

        }
        // Die Methode füllt die TableNames-Liste mit dem Eingabewert
        public void FillTableNamesList()
        {
            TableNames.Add(TableName);
            TableName = "";
            GetDataCommand.RaiseExecuteChanged();
        }
        // Die Methode löscht den ausgewählten Listeneintrag
        public void DeleteTableNamesEntry()
        {
            TableNames.Remove(SelectedTable);
        }
    }
}

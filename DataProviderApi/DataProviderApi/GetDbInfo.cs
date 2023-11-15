using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataProviderApi {
    public class GetDbInfo {
        private string connectionString = @"EU51SQLQ005\DEQUAL01;Database={dbName};Integrated Security=true;";
        private string tableName;
        public GetDbInfo() {
            
        }
        public string GetTableScheme(string tableName) {
            StringBuilder insertScript = new StringBuilder();
            string selectQuery = $"SELECT * FROM {tableName}";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection)) {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) {

                        using (DataTable dataTable = new DataTable()) {
                            adapter.Fill(dataTable);

                            foreach (DataRow row in dataTable.Rows) {
                                insertScript.Append($"INSERT INTO {tableName} (");

                                foreach (DataColumn column in dataTable.Columns) {
                                    string columnName = column.ColumnName;
                                    insertScript.Append($"{columnName}, ");
                                }

                                insertScript.Length -= 2; // Entfernt Komma und Leerzeichen
                                insertScript.AppendLine(") VALUES (");

                                foreach (DataColumn column in dataTable.Columns) {
                                    object value = row[column];
                                    string valueString = (value != DBNull.Value) ? value.ToString() : "NULL";
                                    insertScript.Append($"'{valueString}', ");
                                }

                                insertScript.Length -= 2;
                                insertScript.AppendLine(");");
                            }
                        }

                    }
                }
            }
            return insertScript.ToString();
        }
        public string GetTableItems(string tableName) {
            StringBuilder insertScript = new StringBuilder();
            string selectQuery = $"SELECT * FROM {tableName}";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection)) {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) {

                        using (DataTable dataTable = new DataTable()) {
                            adapter.Fill(dataTable);

                            foreach (DataRow row in dataTable.Rows) {
                                insertScript.Append($"INSERT INTO {tableName} (");

                                foreach (DataColumn column in dataTable.Columns) {
                                    string columnName = column.ColumnName;
                                    insertScript.Append($"{columnName}, ");
                                }

                                insertScript.Length -= 2; // Entfernt Komma und Leerzeichen
                                insertScript.AppendLine(") VALUES (");

                                foreach (DataColumn column in dataTable.Columns) {
                                    object value = row[column];
                                    string valueString = (value != DBNull.Value) ? value.ToString() : "NULL";
                                    insertScript.Append($"'{valueString}', ");
                                }

                                insertScript.Length -= 2;
                                insertScript.AppendLine(");");
                            }
                        }

                    }
                }
            }
            return insertScript.ToString();
        }
    }
}

using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataProviderApi {
    public class GetDbInfo {
        private string connectionString;
        public GetDbInfo(string _connectionString) {
             connectionString = _connectionString;
        }
        public string GetTableScheme(string tableName)
        {
            StringBuilder createScript = new StringBuilder();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //Get tablescheme
                string query = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE " +
                    $"FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        if (reader.HasRows) {
                            //CREATE TABLE 
                            createScript.Append($"CREATE TABLE {tableName} (\n");
                            while (reader.Read()) {
                                string columnName = reader["COLUMN_NAME"].ToString();
                                string dataType = reader["DATA_TYPE"].ToString();
                                string length = reader["CHARACTER_MAXIMUM_LENGTH"].ToString();
                                string isNullable = reader["IS_NULLABLE"].ToString();
                                if (columnName.Contains(' ')){
                                    columnName = $"\"{columnName}\"";
                                }
                                string columnDefinition = $"{columnName} {dataType}";
                                //Set length
                                if (!string.IsNullOrEmpty(length)) columnDefinition += $"({length})";
                                if (isNullable == "YES") columnDefinition += $" NULL";
                                else if (isNullable == "NO") columnDefinition += $" NOT NULL";

                                createScript.Append(columnDefinition);
                                createScript.Append(",\n");
                            }

                            // Entfernt das letzte Komma und Zeilenumbruch.
                            createScript.Remove(createScript.Length - 2, 2);

                            createScript.Append(");");
                        }
                        else {
                            throw new Exception($"Tabelle '{tableName}' nicht gefunden.");
                        }
                        return createScript.ToString();
                    }
                }
            }
        }
        public string GetTableItems(string tableName) {
            StringBuilder insertScript = new StringBuilder();
            string selectQuery = $"SELECT * FROM {tableName}";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection)) {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) {
                        using (DataTable dataTable = new DataTable()) {
                            adapter.Fill(dataTable);

                            insertScript.Append($"INSERT INTO {tableName} ");

                            //foreach (DataColumn column in dataTable.Columns) {
                            //    string columnName = column.ColumnName;
                            //    insertScript.Append($"{columnName}, ");
                            //}

                            insertScript.Length -= 2; //Deletes last comma and space
                            insertScript.AppendLine(" VALUES ");

                            foreach (DataRow row in dataTable.Rows) {
                                insertScript.Append("(");

                                foreach (DataColumn column in dataTable.Columns) {
                                    string columnName = column.ColumnName;
                                    object value = row[column];
                                    string valueString = (value != DBNull.Value) ? $"'{GetReplacementValue(columnName, value)}'" : "NULL";
                                    insertScript.Append($"{valueString}, ");
                                }

                                insertScript.Length -= 2; //Deletes last comma and space
                                insertScript.AppendLine("),");
                            }

                            insertScript.Length -= 3; //Deletes last comma and new line
                            insertScript.AppendLine(";");
                        }
                    }
                }
            }

            return insertScript.ToString();
        }

        private object GetReplacementValue(string columnName, object value) {
            if (columnName == "ClientCode" || columnName == "ContractCode") {
                return 123456;
            }
            else if (columnName == "SensibleNvarcharWert") {
                return 123456;
            }
            return value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetYourDbData {
    public  class LocalDbController {
        public static string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\M8LN\Documents\AbschlussprojektIHK2023\ProjektarbeitIHK2023\GetYourDbData\GetYourDbData\TestEnvironment.mdf;Integrated Security=True";
        private static SqlConnection con = new SqlConnection(conString);

        //Returns the connection String
        public string GetConString() {
            return conString;
        }
        //Updates the current state of the Db 
        public void UpdateDb(string query) {
            con.Open();
            SqlCommand cmd = new SqlCommand(query.ToString(), con);
            cmd.ExecuteNonQuery();
        }
        //This method will set the Db name to TestEnvironment everytime the app gets closed
        public void RenameDbToDeafault() {
            con.Open();
            string getCurrentDbNameQuery = @"SELECT name FROM sys.master_files WHERE physical_name LIKE" +
                                           @"'C:\Users\M8LN\Documents\AbschlussprojektIHK2023\ProjektarbeitIHK2023\GetYourDbData\GetYourDbData\TestEnvironment.mdf';";
            SqlCommand getDbNameCmd = new SqlCommand(getCurrentDbNameQuery, con);
            string currentDbName = getDbNameCmd.ExecuteScalar().ToString();
            string setDbNameToDefaultQuery = $"ALTER DATABASE {currentDbName} MODIFY NAME = TestEnvironment;";
            SqlCommand setDbNameToDefault = new SqlCommand(setDbNameToDefaultQuery, con);

        }
    }
}

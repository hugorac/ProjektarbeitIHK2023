using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetYourDbData {
    internal static class DbController {
        private static string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\M8LN\Documents\AbschlussprojektIHK2023\ProjektarbeitIHK2023\GetYourDbData\GetYourDbData\TestEnvironment.mdf;Integrated Security=True";

        private static string GetConString() {
            return conString;
        }
        public static void UpdateDb(string query) {
            using (SqlConnection con = new SqlConnection(conString)) {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

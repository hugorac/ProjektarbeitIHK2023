using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace GetYourDbData
{
    public class SqlApiServiceClient {
        // Diese Klasse ruft die API
        public async Task<string> GetSqlScript(string dbName, IEnumerable<string> tableNames) {
            HttpClient httpClient = new HttpClient();
            // Die Basis-URL wird aus der App.config wird initialisiert.
            var baseUrl = System.Configuration.ConfigurationManager.AppSettings["api"];
            // Mit StringBuilder wird mit der Basis-URL als 'url' initialisiert anschließend wird die
            // ganze URL erstellt und die API gerufen.
            StringBuilder url = new StringBuilder(baseUrl);
            
            url.Append($"/hugo-dataprovider/DataProvider?dbName={dbName}");
            foreach (var table in tableNames) {
                url.Append($"&tableNames={table}");
            }
            var response = await httpClient.GetAsync(url.ToString()).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}

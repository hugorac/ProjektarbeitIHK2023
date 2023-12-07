using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using System.Net.Http;

namespace GetYourDbData {
    public class ApiRequester {
        //This method will do a request to the API
        public async Task<string> GetSqlScript(string dbName, List<string> tableNames) {
            StringBuilder url = new StringBuilder();
            url.Append($"https://appserver.qual.euris.eurofins.local/api/hugo-dataprovider/DataProvider?dbName={dbName}");
            foreach (var table in tableNames) {
                url.Append($"&tableNames={table}");
            }
            Uri uri = new Uri(url.ToString());
            var client = new HttpClient();
            client.BaseAddress = uri;
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}

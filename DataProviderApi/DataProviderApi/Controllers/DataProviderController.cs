using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DataProviderApi.Controllers {
    public class DataProviderController : ControllerBase {
        [Route("[controller]")]
        [HttpGet]
        public IActionResult GetData(string dbName, List<string> tableNames) {
            GetDbInfo getDbInfo = new GetDbInfo(@$"Server=EU51SQLQ005\DEQUAL01;Database={dbName};Integrated Security=true;");
            StringBuilder result = new StringBuilder();
            result.AppendLine($"USE MASTER");
            result.AppendLine("GO");
            result.AppendLine($"CREATE DATABASE {dbName}");
            result.AppendLine("GO");
            result.AppendLine($"USE {dbName}");
            result.AppendLine("GO");
            foreach (var table in tableNames) {
                result.AppendLine($"{getDbInfo.GetTableScheme(table)} {getDbInfo.GetTableItems(table)}");
            }
            return Ok(result.ToString());
        }
        
    }
}

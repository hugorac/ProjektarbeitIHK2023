using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DataProviderApi.Controllers {
    public class DataProviderController : ControllerBase {
        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult GetData(string dbName, List<string> tableNames) {
            GetDbInfo getDbInfo = new GetDbInfo(@$"Server=EU51SQLQ005\DEQUAL01;Database={dbName};Integrated Security=true;");
            StringBuilder result = new StringBuilder();
            result.Append($"CREATE DATABASE {dbName}; ");
            foreach (var table in tableNames) {
                result.Append($"{getDbInfo.GetTableScheme(table)} {getDbInfo.GetTableItems(table)}");
            }
            return Ok(result.ToString());
        }
    }
}

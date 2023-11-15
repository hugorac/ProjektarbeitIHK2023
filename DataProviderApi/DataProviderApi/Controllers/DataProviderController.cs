using Microsoft.AspNetCore.Mvc;

namespace DataProviderApi.Controllers {
    public class DataProviderController : ControllerBase {
        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult GetData(string dbName, string tableName) {
            GetDbInfo getDbInfo = new GetDbInfo(@$"Server=EU51SQLQ005\DEQUAL01;Database={dbName};Integrated Security=true;");
            string result = $"CREATE DATABASE {dbName};\n{getDbInfo.GetTableScheme(tableName)}\n{getDbInfo.GetTableItems(tableName)}";
            return Ok(result);
        }
    }
}

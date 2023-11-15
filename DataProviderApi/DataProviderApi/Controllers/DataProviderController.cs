using Microsoft.AspNetCore.Mvc;

namespace DataProviderApi.Controllers {
    public class DataProviderController : ControllerBase {
        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult GetData(string dbName, string tableName) {
            GetDbInfo getDbInfo = new GetDbInfo();
            string result = $"USE {dbName}\n{getDbInfo.GetTableScheme(tableName)}\n{getDbInfo.GetTableItems(tableName)}";
            return Ok(result);
        }
    }
}

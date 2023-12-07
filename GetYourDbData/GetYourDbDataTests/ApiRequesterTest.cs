
using GetYourDbData;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetYourDbDataTests
{
    [TestFixture]
    public class ApiRequesterTests
    {
        [Test]
        public async Task GetSqlScript_ReturnsString()
        {
            // Arrange
            ApiRequester apiRequester = new ApiRequester();

            // Act
            string dbName = "EuReCa";
            List<string> tableNames = new List<string> { "HerbcategoryList", "Labsites" };
            string result = await apiRequester.GetSqlScript(dbName, tableNames);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<string>(result);
            
        }
    }
}
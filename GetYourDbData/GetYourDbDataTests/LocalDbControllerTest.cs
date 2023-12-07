using GetYourDbData;
using NUnit.Framework;
using System.Data.SqlClient;

namespace GetYourDbDataTests
{
    
    [TestFixture]
    public class LocalDbControllerTests
    {
        // See 
        [Test]
        public void GetConString_ReturnsString()
        {
            // Arrange
            LocalDbController localDbController = new LocalDbController();

            // Act
            string connectionString = localDbController.GetConString();

            // Assert
            Assert.IsNotNull(connectionString);
            Assert.IsInstanceOf<string>(connectionString);
        }

        // Test the database connection
        [Test]
        public void OpenDbConnection()
        {
            // Arrange 
            LocalDbController localDbController = new LocalDbController();
            SqlConnection sqlConnection = new SqlConnection(localDbController.GetConString());

            // Act
            bool isDbConnectionOpen = localDbController.IsDbConnectionSuccessfully();

            // Assert
            Assert.IsTrue(isDbConnectionOpen);

        }
    }
    
}
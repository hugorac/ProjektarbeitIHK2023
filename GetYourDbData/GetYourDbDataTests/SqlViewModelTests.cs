using NUnit.Framework;
using System.Collections.ObjectModel;

namespace GetYourDbData.Tests
{
    [TestFixture]
    public class SqlViewModelTests
    {
        private SqlViewModel sqlViewModel;

        [SetUp]
        public void SetUp()
        {
            // Vorbereitung für Tests: Erstellen einer neuen Instanz der SqlViewModel-Klasse
            sqlViewModel = new SqlViewModel();
        }

        [Test]
        public void FillTableNamesList_AddTableName_UpdatesTableNamesList()
        {
            // Arrange
            string tableName = "TESTTABLE";

            // Act
            sqlViewModel.TableName = tableName;
            sqlViewModel.FillTableNamesList();

            // Assert
            CollectionAssert.Contains(sqlViewModel.TableNames, tableName);
        }
    }
}

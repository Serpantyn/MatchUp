using MatchUp.Model;

namespace MatchUpTests
{
    [TestClass]
    [DoNotParallelize]
    public class SaveDataTest
    {
        private readonly string testFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "saved_data.json");

        private void ClearFileBeforeTest()
        {
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        private void DeleteFileAfterTest()
        {
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [TestMethod]
        public void TestLoadEmptyFile()
        {
            ClearFileBeforeTest();
            // Act
            List<SaveData> result = SaveData.Load();

            // Assert
            Assert.AreEqual(0, result.Count);

            DeleteFileAfterTest();
        }

        [TestMethod]
        public void TestSaveAndLoadData()
        {
            ClearFileBeforeTest();

            // Arrange
            var saveData = new SaveData("Player1", DateTime.Now, 6, 5, "2:00");
            var dataList = new List<SaveData> { saveData };

            SaveData.Save(dataList);

            // Act
            List<SaveData> loadedData = SaveData.Load();

            // Assert
            Assert.AreEqual(1, loadedData.Count);
            Assert.AreEqual("Player1", loadedData[0].Name);
            Assert.AreEqual(6, loadedData[0].AmountOfCards);
            Assert.AreEqual(5, loadedData[0].AmountOfAttempts);
            Assert.AreEqual("2:00", loadedData[0].Time);

            DeleteFileAfterTest();
        }

        [TestMethod]
        public void TestAddNewData()
        {
            ClearFileBeforeTest();
            // Arrange
            var saveData1 = new SaveData("Player1", DateTime.Now, 6, 5, "2:00");
            var saveData2 = new SaveData("Player2", DateTime.Now, 8, 7, "3:00");

            var dataList = new List<SaveData> { saveData1 };

            SaveData.Save(dataList);
            SaveData.AddNew(new List<SaveData> { saveData2 });

            // Act
            List<SaveData> loadedData = SaveData.Load();

            // Assert
            Assert.AreEqual(2, loadedData.Count); 
            Assert.AreEqual("Player2", loadedData[1].Name);

            DeleteFileAfterTest();
        }
    }
}

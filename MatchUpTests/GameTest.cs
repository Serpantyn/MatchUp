using MatchUp.Model;

namespace MatchUpTests
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void TestGameInitialization()
        {
            // Arrange
            int numberOfPairs = 6;
            bool isTimer = true;
            string playerName = "Player1";

            // Act
            Game game = new Game(numberOfPairs, isTimer, playerName);

            // Assert
            Assert.AreEqual(numberOfPairs, game.cardsCollection.Cards.Count);
            Assert.AreEqual(isTimer, game.IsTimer);
            Assert.AreEqual(playerName, game.Name); 
            Assert.AreEqual(0, game.Attempts);
        }

        [TestMethod]
        public void TestAllCardsOpen()
        {
            // Arrange
            int numberOfPairs = 6;
            Game game = new Game(numberOfPairs, true, "Player1");

            // Act
            bool allCardsOpenBefore = game.AllCardsOpen();

            foreach (var card in game.cardsCollection.Cards)
            {
                card.IsOpen = true;
            }

            bool allCardsOpenAfter = game.AllCardsOpen();

            // Assert
            Assert.IsFalse(allCardsOpenBefore);
            Assert.IsTrue(allCardsOpenAfter);
        }

        [TestMethod]
        public void TestAttemptsIncrement()
        {
            // Arrange
            Game game = new Game(6, true, "Player1");

            // Act
            game.Attempts++;
            game.Attempts++;

            // Assert
            Assert.AreEqual(2, game.Attempts);
        }

        [TestMethod]
        public void TestTimeSetter()
        {
            // Arrange
            Game game = new Game(6, true, "Player1");

            // Act
            game.Time = "1:30";

            // Assert
            Assert.AreEqual("1:30", game.Time);
        }
    }
}

using MatchUp.Model;

namespace MatchUpTests
{
    [TestClass]
    public class CardsCollectionTest
    {
        [TestMethod]
        public void TestCardsCollectionInitialization()
        {
            // Arrange
            int amountOfCards = 6; 
            CardsCollection cardsCollection = new CardsCollection(amountOfCards);

            // Act
            int expectedPairCount = amountOfCards / 2;
            var distinctCardIds = cardsCollection.Cards.Select(c => c.Id).Distinct().Count();

            // Assert
            Assert.AreEqual(expectedPairCount, distinctCardIds);
            Assert.AreEqual(amountOfCards, cardsCollection.Cards.Count); 
        }

        [TestMethod]
        public void TestCardsShuffling()
        {
            // Arrange
            int amountOfCards = 6; 
            CardsCollection cardsCollection1 = new CardsCollection(amountOfCards);
            CardsCollection cardsCollection2 = new CardsCollection(amountOfCards);

            // Act
            bool areDifferent = !cardsCollection1.Cards.SequenceEqual(cardsCollection2.Cards);

            // Assert
            Assert.IsTrue(areDifferent, "Картки повинні бути перемішані");
        }

        [TestMethod]
        public void TestGeneratedCardsPairing()
        {
            // Arrange
            int amountOfCards = 6; 
            CardsCollection cardsCollection = new CardsCollection(amountOfCards);

            // Act
            var groups = cardsCollection.Cards.GroupBy(c => c.Id).ToList();

            // Assert
            Assert.AreEqual(3, groups.Count); 
            foreach (var group in groups)
            {
                Assert.AreEqual(2, group.Count());
            }
        }
    }
}
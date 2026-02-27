using MatchUp.Model;

namespace MatchUpTests
{
    [TestClass]
    public sealed class CardTest
    {
        [TestMethod]
        public void TestCardInitialization()
        {
            // Arrange
            int expectedId = 1;
            bool expectedIsOpen = false;
            string expectedImagePath = "path/to/image.png";

            // Act
            Card card = new Card(expectedId, expectedIsOpen, expectedImagePath);

            // Assert
            Assert.AreEqual(expectedId, card.Id);
            Assert.AreEqual(expectedIsOpen, card.IsOpen);
            Assert.AreEqual(expectedImagePath, card.ImagePath);
        }

        [TestMethod]
        public void TestCardSetters()
        {
            // Arrange
            int Id = 1;
            bool IsOpen = false;
            string ImagePath = "path/to/image.png";

            // Act
            Card card = new Card(0, true, "some/path.png");
            card.Id = Id;
            card.IsOpen = IsOpen;
            card.ImagePath = ImagePath;


            // Assert
            Assert.AreEqual(1, card.Id);
            Assert.AreEqual(false, card.IsOpen);
            Assert.AreEqual("path/to/image.png", card.ImagePath);
        }

        [TestMethod]
        public void TestDisplayedImagePathWhenCardIsClosed()
        {
            // Arrange
            string expectedImagePath = "path/to/image.png";
            Card card = new Card(1, false, expectedImagePath);

            // Act
            string displayedImagePath = card.DisplayedImagePath;

            // Assert
            Assert.AreEqual("pack://application:,,,/Images/backSide.png", displayedImagePath);
        }

        [TestMethod]
        public void TestDisplayedImagePathWhenCardIsOpen()
        {
            // Arrange
            string expectedImagePath = "path/to/image.png";
            Card card = new Card(1, true, expectedImagePath);

            // Act
            string displayedImagePath = card.DisplayedImagePath;

            // Assert
            Assert.AreEqual(expectedImagePath, displayedImagePath);
        }

        [TestMethod]
        public void TestCardEqualityOperator()
        {
            // Arrange
            Card card1 = new Card(1, false, "path/to/image1.png");
            Card card2 = new Card(1, false, "path/to/image2.png");
            Card card3 = new Card(2, false, "path/to/image3.png");

            // Act & Assert
            Assert.IsTrue(card1 == card2); 
            Assert.IsFalse(card1 == card3);
        }

        [TestMethod]
        public void TestCardInequalityOperator()
        {
            // Arrange
            Card card1 = new Card(1, false, "path/to/image1.png");
            Card card2 = new Card(1, false, "path/to/image2.png");
            Card card3 = new Card(2, false, "path/to/image3.png");

            // Act & Assert
            Assert.IsFalse(card1 != card2); 
            Assert.IsTrue(card1 != card3);
        }

        [TestMethod]
        public void TestCardEqualsMethod()
        {
            // Arrange
            Card card1 = new Card(1, false, "path/to/image1.png");
            Card card2 = new Card(1, false, "path/to/image2.png");
            Card card3 = new Card(2, false, "path/to/image3.png");

            // Act & Assert
            Assert.IsTrue(card1.Equals(card2));
            Assert.IsFalse(card1.Equals(card3));
            Assert.IsFalse(card1.Equals("string"));
        }

        [TestMethod]
        public void TestCardGetHashCode()
        {
            // Arrange
            Card card1 = new Card(1, false, "path/to/image1.png");
            Card card2 = new Card(1, false, "path/to/image2.png");

            // Act & Assert
            Assert.AreEqual(card1.GetHashCode(), card2.GetHashCode());
        }
    }
}

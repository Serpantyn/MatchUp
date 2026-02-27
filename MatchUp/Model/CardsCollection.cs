namespace MatchUp.Model
{
    public class CardsCollection
    {
        public List<Card> Cards { get; private set; }
        public int amountOfCards;

        public CardsCollection(int amountOfCards)
        {
            Cards = new List<Card>();
            GenerateCards(amountOfCards / 2);
            ShuffleCards();
            this.amountOfCards = amountOfCards;
        }

        private void GenerateCards(int numberOfPairs)
        {
            var random = new Random();
            for (int i = 1; i <= numberOfPairs; i++)
            {
                string imagePath = "pack://application:,,,/Images/fruits" + $"/{i}.png"; 
                Cards.Add(new Card(i, false, imagePath));
                Cards.Add(new Card(i, false, imagePath));
            }
        }

        private void ShuffleCards()
        {
            var random = new Random();
            Cards = Cards.OrderBy(c => random.Next()).ToList();
        }
    }

}

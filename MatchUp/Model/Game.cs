namespace MatchUp.Model
{
    public class Game
    {
        public CardsCollection cardsCollection;
        public Stack<Card> currentPair;
        private bool isTimer = false;
        private int attempts;
        private string time = "0:00";
        private string name;

        public bool IsTimer
        {
            get { return isTimer; }
            set { isTimer = value; }
        }

        public int Attempts
        {
            get { return attempts; }
            set { attempts = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Game(int numberOfPairs, bool isTimer, string name)
        {
            cardsCollection = new CardsCollection(numberOfPairs);
            currentPair = new Stack<Card>();
            attempts = 0;
            IsTimer = isTimer;
            Name = name;
        }

        public bool AllCardsOpen()
        {
            return cardsCollection.Cards.All(card => card.IsOpen);
        }

    }
}

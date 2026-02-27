using MatchUp.Utilities;

namespace MatchUp.Model
{
    public class Card : ViewModelBase 
    {
        private int id;
        private bool isOpen;
        private string imagePath;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public bool IsOpen
        {
            get => isOpen;
            set
            {
                isOpen = value;
                OnPropertyChanged(nameof(IsOpen));
                OnPropertyChanged(nameof(DisplayedImagePath));
            }
        }

        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
                OnPropertyChanged(nameof(DisplayedImagePath));
            }
        }

        public string DisplayedImagePath => IsOpen ? ImagePath : "pack://application:,,,/Images/backSide.png";

        public Card(int id, bool isOpen, string imagePath)
        {
            this.id = id;
            this.isOpen = isOpen;
            this.imagePath = imagePath;
        }

        public static bool operator ==(Card first, Card second)
        {
            return first.Id == second.Id;
        }

        public static bool operator !=(Card first, Card second)
        {
            return !(first == second);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Card card)
            {
                return card.Id.Equals(this.Id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

}

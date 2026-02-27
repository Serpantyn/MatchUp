using MatchUp.Model;
using MatchUp.Utilities;
using System.Windows;
using System.Windows.Input;
using Top.Utilities;

namespace MatchUp.ViewModel
{
    class CongratulationsVM : ViewModelBase
    {
        private string _cards;
        public string Cards
        {
            get { return _cards; }
            set
            {
                _cards = value;
                OnPropertyChanged(nameof(Cards)); 
            }
        }
        private string _attempts;
        public string Attempts
        {
            get { return _attempts; }
            set
            {
                _attempts = value;
                OnPropertyChanged(nameof(Attempts));
            }
        }
        private string _time;
        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public ICommand ContinueCommand { get; set; }

        public CongratulationsVM(Game game)
        {
            ContinueCommand = new RelayCommand(Continue, CanCancel);

            Cards = "Cards: " + game.cardsCollection.amountOfCards.ToString();
            Attempts = "Attempts: " + game.Attempts.ToString();
            Time = "Time: " + game.Time;
            Name = game.Name;

            SaveData save = new SaveData(game.Name, DateTime.Now, game.cardsCollection.amountOfCards, game.Attempts, game.Time);
            SaveData.AddNew([save]);
        }

        private bool CanCancel(object arg) => true;

        private void Continue(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }

            NavigationService.Navigation.ShowHome();
        }
    }
}

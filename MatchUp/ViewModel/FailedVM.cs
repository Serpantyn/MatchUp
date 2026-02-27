using MatchUp.Model;
using MatchUp.Utilities;
using System.Windows;
using System.Windows.Input;
using Top.Utilities;

namespace MatchUp.ViewModel
{
    class FailedVM : ViewModelBase
    {
        private int amountOfCards;
        private bool timer;
        private string name;
        public ICommand ContinueCommand { get; set; }
        public ICommand RestartCommand { get; set; }

        public FailedVM(Game game)
        {
            ContinueCommand = new RelayCommand(Continue, CanCancel);
            RestartCommand = new RelayCommand(Restart, CanCancel);

            amountOfCards = game.cardsCollection.amountOfCards;
            timer = game.IsTimer;
            name = game.Name;
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

        private void Restart(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }

            Game newGame = new Game(amountOfCards, timer, name);
            NavigationService.Navigation.ShowMain(newGame);
        }
    }
}

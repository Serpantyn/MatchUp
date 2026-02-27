using MatchUp.Model;
using MatchUp.Utilities;
using System.Windows;
using System.Windows.Input;
using Top.Utilities;

namespace MatchUp.ViewModel
{
    class SelectModeVM : ViewModelBase
    {
        private int _selectedCardCount;
        public int SelectedCardCount
        {
            get { return _selectedCardCount; }
            set
            {
                _selectedCardCount = value;
                OnPropertyChanged(nameof(SelectedCardCount));
            }
        }

        private bool _isTimeLimitEnabled;
        public bool IsTimeLimitEnabled
        {
            get { return _isTimeLimitEnabled; }
            set
            {
                if (_isTimeLimitEnabled != value)
                {
                    _isTimeLimitEnabled = value;
                    OnPropertyChanged(nameof(IsTimeLimitEnabled));  // Оновлюємо UI
                }
            }
        }

        public ICommand CancelCommand { get; set; }
        public ICommand ContinueCommand { get; set; }
        public List<int> Options { get; set; }
        private string Name;


        public SelectModeVM(string name)
        {
            CancelCommand = new RelayCommand(Cancel, CanCancel);
            ContinueCommand = new RelayCommand(Continue, CanCancel);

            Options = new List<int> { 10, 20, 30 };
            IsTimeLimitEnabled = false;
            Name = name;
        }

        private bool CanCancel(object arg) => true;

        private void Cancel(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }
        }

        private void Continue(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }

            if (SelectedCardCount > 0)
            {
                NavigationService.Name = Name;
                Game game = new Game(SelectedCardCount, IsTimeLimitEnabled, Name);
                NavigationService.Navigation.ShowMain(game);
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть кількість карток.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}

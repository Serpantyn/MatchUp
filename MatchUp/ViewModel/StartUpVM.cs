using MatchUp.Utilities;
using MatchUp.View;
using System.Windows;
using System.Windows.Input;
using Top.Utilities;

namespace MatchUp.ViewModel
{
    class StartUpVM : ViewModelBase
    {

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

        public ICommand StartGameCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public ICommand ScoresCommand { get; private set; }

        public StartUpVM()
        {
            StartGameCommand = new RelayCommand(StartGame, CanShowWindow);
            ExitCommand = new RelayCommand(Exit, CanShowWindow);
            ScoresCommand = new RelayCommand(Scores, CanShowWindow);

            if (NavigationService.Name != "")
            {
                Name = NavigationService.Name;
            }
        }

        private bool CanShowWindow(object arg)
        {
            return true;
        }

        private void StartGame(object obj)
        {
            try
            {
                if (string.IsNullOrEmpty(Name))
                {
                    throw new Exception("Name cannot be empty");
                }

                if (Name.Length > 12)
                {
                    Name = "";
                    throw new Exception("Name is too long");
                }

                if (!Name.All(char.IsLetter))
                {
                    Name = "";
                    throw new Exception("Name should contain only letters");
                }
            }
            catch(Exception ex)
            {
                ErrorHandling.ShowErrorMessage(ex);
                return;
            }

            Name = char.ToUpper(Name[0]) + Name.Substring(1);
            SelectMode selectMode = new SelectMode(Name);
            selectMode.ShowDialog();
        }

        private void Exit(object obj)
        {
            Application.Current.Shutdown();
        }

        private void Scores(object obj)
        {
            Savings saving = new Savings();
            saving.ShowDialog();
        }
    }
}

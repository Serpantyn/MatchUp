using MatchUp.Model;
using MatchUp.Utilities;
using MatchUp.View;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Top.Utilities;

namespace MatchUp.ViewModel
{
    class MainVM : ViewModelBase
    {
        private DispatcherTimer timer;
        private int secondsElapsed;
        private int countdownSeconds;

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

        private string _imagePathClock;
        public string ImagePathClock
        {
            get { return _imagePathClock; }
            set
            {
                _imagePathClock = value;
                OnPropertyChanged(nameof(ImagePathClock));
            }
        }

        private double _width;
        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        private double _height;
        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        private Thickness _firstMargin = new Thickness(10, 10, 10, 10);
        public Thickness FirstMargin
        {
            get { return _firstMargin; }
            set
            {
                _firstMargin = value;
                OnPropertyChanged(nameof(FirstMargin));
            }
        }

        private Thickness _secondMargin = new Thickness(10, 10, 10, 10);
        public Thickness SecondMargin
        {
            get { return _secondMargin; }
            set
            {
                _secondMargin = value;
                OnPropertyChanged(nameof(SecondMargin)); 
            }
        }

        public Game currentGame;
        private bool isProcessing = false; 

        public ObservableCollection<Card> Cards { get; }

        public ICommand PauseCommand { get; private set; }
        public ICommand OpenCardCommand { get; }

        public MainVM(Game game)
        {
            PauseCommand = new RelayCommand(Pause, CanShowWindow);
            OpenCardCommand = new RelayCommand(OpenCard, CanShowWindow);
            currentGame = game;

            Cards = new ObservableCollection<Card>(game.cardsCollection.Cards);
            Attempts = "0";
            Time = "0:00";
            ImagePathClock = currentGame.IsTimer ? "pack://application:,,,/Images/icons-sand-clock.png" : "pack://application:,,,/Images/icons-clock.png";

            if (currentGame.IsTimer)
            {
                StartCountdownTimer();
            }
            else
            {
                StartTimer();
            }

            if (currentGame.cardsCollection.amountOfCards == 10)
            {
                Width = 110;
                Height = 130;
                FirstMargin = new Thickness(5, 5, 5, 5);
                SecondMargin = new Thickness(15, 15, 15, 15);
            }
            else if (currentGame.cardsCollection.amountOfCards == 20)
            {
                Width = 80;
                Height = 94.54;
                FirstMargin = new Thickness(5, 5, 5, 5);
                SecondMargin = new Thickness(10, 10, 10, 10);
            }
            else if (currentGame.cardsCollection.amountOfCards == 30)
            {
                Width = 65;
                Height = 76.81;

                FirstMargin = new Thickness(5, 5, 5, 5);
                SecondMargin = new Thickness(5, 5, 5, 5);
            }
        }

        private void StartTimer()
        {
            secondsElapsed = 0;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            secondsElapsed++;
            Time = $"{secondsElapsed / 60}:{secondsElapsed % 60:D2}";
        }

        private void StopTimer()
        {
            timer?.Stop();
        }

        private void StartCountdownTimer()
        {
            if(currentGame.cardsCollection.amountOfCards == 10) countdownSeconds = 20; 
            else if (currentGame.cardsCollection.amountOfCards == 20) countdownSeconds = 60;
            else if (currentGame.cardsCollection.amountOfCards == 30) countdownSeconds = 120;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += CountdownTimer_Tick;
            timer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (countdownSeconds > 0)
            {
                countdownSeconds--;
                Time = $"{countdownSeconds / 60}:{countdownSeconds % 60:D2}";
            }
            else
            {
                StopTimer();
                Failed failed = new Failed(currentGame);
                failed.ShowDialog();
            }
        }

        private bool CanShowWindow(object arg)
        {
            return true;
        }

        private void Pause(object obj)
        {
            timer.Stop();
            PauseMode pauseMode = new PauseMode();
            pauseMode.ShowDialog();
            timer.Start();
        }

        private async void OpenCard(object parameter)
        {
            if (isProcessing) return;

            if (parameter is Card card && !card.IsOpen)
            {
                isProcessing = true;

                card.IsOpen = !card.IsOpen; 

                currentGame.currentPair.Push(card);

                if (currentGame.currentPair.Count == 2)
                {
                    var opened = currentGame.currentPair.ToList();

                    if (opened[0] != opened[1])
                    {
                        await Task.Delay(1000);

                        opened.ForEach(card => card.IsOpen = false);
                    }

                    currentGame.currentPair.Clear();
                    currentGame.Attempts += 1;
                    Attempts = currentGame.Attempts.ToString();
                }

                if (currentGame.AllCardsOpen())
                {
                    StopTimer();
                    if (currentGame.IsTimer)
                    {
                        int all = 0;
                        if (currentGame.cardsCollection.amountOfCards == 10) all = 20;
                        else if (currentGame.cardsCollection.amountOfCards == 20) all = 60;
                        else if (currentGame.cardsCollection.amountOfCards == 30) all = 120;

                        all -= countdownSeconds;
                        currentGame.Time = $"{all / 60}:{all % 60:D2}";
                    }
                    else
                    {
                        currentGame.Time = Time;
                    }
                    Congratulations congrats = new Congratulations(currentGame);
                    congrats.ShowDialog();
                }

                isProcessing = false;
            }
        }
    }
}

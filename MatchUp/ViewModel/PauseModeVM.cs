using MatchUp.Utilities;
using System.Windows;
using System.Windows.Input;
using Top.Utilities;

namespace MatchUp.ViewModel
{
    class PauseModeVM : ViewModelBase
    {
        public ICommand CancelCommand { get; set; }
        public ICommand LeaveCommand { get; set; }

        public PauseModeVM()
        {
            CancelCommand = new RelayCommand(Cancel, CanCancel);
            LeaveCommand = new RelayCommand(Leave, CanCancel);
        }

        private bool CanCancel(object arg) => true;

        private void Cancel(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }
        }

        private void Leave(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }

            NavigationService.Navigation.ShowHome();
        }

    }
}

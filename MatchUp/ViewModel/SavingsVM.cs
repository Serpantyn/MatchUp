using MatchUp.Model;
using MatchUp.Utilities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Top.Utilities;

namespace MatchUp.ViewModel
{
    class SavingsVM : ViewModelBase
    {
        public ICommand CloseCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private ObservableCollection<SaveData> _savedData;
        public ObservableCollection<SaveData> SavedData
        {
            get => _savedData;
            set
            {
                _savedData = value;
                OnPropertyChanged(nameof(SavedData));
            }
        }

        public SavingsVM()
        {
            CloseCommand = new RelayCommand(Close, CanCancel);
            DeleteCommand = new RelayCommand(Delete, CanCancel);

            List<SaveData> result = SaveData.Load();
            SavedData = new ObservableCollection<SaveData>(result.AsEnumerable().Reverse().ToList());
        }

        private bool CanCancel(object arg) => true;

        private void Close(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }
        }

        private void Delete(object obj)
        {
            if (obj is SaveData item)
            {
                SavedData.Remove(item);
                SaveData.Save(SavedData.AsEnumerable().Reverse().ToList());
            }
        }
    }
}

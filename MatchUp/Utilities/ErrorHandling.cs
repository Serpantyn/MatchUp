using log4net;
using System.Windows;

namespace MatchUp.Utilities
{
    public static class ErrorHandling
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ErrorHandling));

        public static void LogError(Exception ex)
        {
            log.Error("Помилка:", ex);
        }

        public static void ShowErrorMessage(Exception ex)
        {
            log.Error("Сталася помилка:", ex);
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

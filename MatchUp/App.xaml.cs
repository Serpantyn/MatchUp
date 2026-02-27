using MatchUp.ViewModel;
using MatchUp.Utilities;
using System.Configuration;
using System.Data;
using System.Windows;
using log4net.Config;
using log4net;
using System.IO;

namespace MatchUp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Ініціалізація log4net
        var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

        // Додаємо логування запуску
        ILog log = LogManager.GetLogger(typeof(App));
        log.Info("Додаток запущено");

        NavigationService.Navigation = new NavigationVM();
        NavigationService.Name = "";

        MainWindow mainWindow = new MainWindow
        {
            DataContext = NavigationService.Navigation
        };

        mainWindow.Show();
    }

}


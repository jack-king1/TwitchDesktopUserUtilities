using System.Configuration;
using System.Data;
using System.Windows;
using TwitchDesktopApp.Model.Database;
using TwitchDesktopApp.Services;

namespace TwitchDesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            TwitchAPI api = new TwitchAPI();
            //Init database.
            Database.CreateDB();
        }
    }

}

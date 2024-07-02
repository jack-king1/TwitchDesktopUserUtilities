using System.Configuration;
using System.Data;
using System.Windows;
using TwitchDesktopApp.Model.Database;
using TwitchDesktopApp.Model.Users;
using TwitchDesktopApp.Services;

namespace TwitchDesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        UserAdmin? admin;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            TwitchAPI.initAPIAdmin("lilkinggy");
            //Init database.
            Database.CreateDB();
        }
    }

}

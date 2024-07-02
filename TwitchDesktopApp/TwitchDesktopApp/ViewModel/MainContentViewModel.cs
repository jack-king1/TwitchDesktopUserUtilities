using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TwitchDesktopApp.Model.Enums;



namespace TwitchDesktopApp.ViewModel
{

    internal class MainContentViewModel : INotifyPropertyChanged
    {
        private ViewType _currentView;

        public MainContentViewModel()
        {
            CurrentView = ViewType.SetupPage; // Default view
        }

        public ViewType CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ShowSetupPage()
        {
            CurrentView = ViewType.SetupPage;
        }

        public void ShowScheduleAdsPage()
        {
            CurrentView = ViewType.ScheduleAdsPage;
        }

        public void ShowRaidPage()
        {
            CurrentView = ViewType.RaidPage;
        }
    }
}

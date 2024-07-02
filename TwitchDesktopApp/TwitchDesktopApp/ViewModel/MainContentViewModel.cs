using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TwitchDesktopApp.Core.Commands;
using TwitchDesktopApp.Model.Enums;



namespace TwitchDesktopApp.ViewModel
{

    internal class MainContentViewModel : INotifyPropertyChanged
    {
        private ViewType _currentView;
        public ViewType CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        private ViewType _selectedViewType;
        public ViewType SelectedViewType
        {
            get { return _selectedViewType; }
            set
            {
                if (_selectedViewType != value)
                {
                    _selectedViewType = value;
                    OnPropertyChanged();
                    // Update CurrentView based on the selected view type
                    CurrentView = _selectedViewType;
                }
            }
        }

        public MainContentViewModel()
        {
            // Initialize with the default view
            CurrentView = ViewType.SetupPage;
            SelectedViewType = ViewType.SetupPage;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

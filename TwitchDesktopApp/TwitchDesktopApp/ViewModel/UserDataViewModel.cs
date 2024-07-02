using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TwitchDesktopApp.Core.Commands;
using TwitchDesktopApp.Services;

namespace TwitchDesktopApp.ViewModel
{
    internal class UserDataViewModel : INotifyPropertyChanged
    {
        //Fields
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddUserCommand { get; }

        public UserDataViewModel()
        {
            AddUserCommand = new RelayCommand(AddUser, CanAddUsername);
        }

        private void AddUser(object parameter)
        {
            TwitchAPI.initAPIAdmin(Username);
        }

        private bool CanAddUsername(object parameter)
        {
            return !string.IsNullOrEmpty(Username); //return true always, need to change so if username is connected or somthn
        }


        //The callermembername is a smart autamtic way of using the function. It will automatically pass in the call member name when used in a Setter or method.
        //Therefore if used inside a method it woul pass in AddUser for example but because its inside a setter it passes in that field name.
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

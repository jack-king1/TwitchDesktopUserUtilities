using System.ComponentModel;
using System.Windows.Input;
using TwitchDesktopApp.Core.Commands;

namespace TwitchDesktopApp.ViewModel
{
    internal class UserDataViewModel : INotifyPropertyChanged
    {
        public ICommand AddUserCommand { get; }

        public UserDataViewModel()
        {
            AddUserCommand = new RelayCommand(AddUser, CanAddUsername);
        }

        private void AddUser(object parameter)
        {
            //Implement what happens when we add a user.
            //e.g. add it to the model.
            Console.Write("Being CAlled!");
        }

        private bool CanAddUsername(object parameter)
        {
            return true; //return true always, need to change so if username is connected or somthn
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

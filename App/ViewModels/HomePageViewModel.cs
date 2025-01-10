using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Services;

namespace App.ViewModels
{
    public class HomePageViewModel : ObservableObject
    {
        private string _username;
        private string _password;
        private readonly AuthService _authService;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public ICommand LoginCommand { get; }

        public HomePageViewModel()
        {
            _authService = new AuthService();
            LoginCommand = new RelayCommand(OnLogin);
        }
        private void OnLogin()
        {
            bool isAuthenticated = _authService.Authenticate(Username, Password);

            if (isAuthenticated)
            {
                // Логин успешен
                Debug.WriteLine("Успешный логин");
            }
            else
            {
                // Логин не удался
                Debug.WriteLine("Провал");
            }
        }
        public class RelayCommand : ICommand
        {
            private readonly Action _execute;
            private readonly Func<bool> _canExecute;

            public RelayCommand(Action execute, Func<bool> canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute();
            }

            public void Execute(object parameter)
            {
                _execute();
            }

            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }

            public event EventHandler CanExecuteChanged;
        }
    }
}

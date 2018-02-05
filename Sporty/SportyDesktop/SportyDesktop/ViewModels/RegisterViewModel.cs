using Models.DomainModels;
using Repository.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SportyDesktop.ViewModels;

namespace SportyDesktop.ViewModels
{
    public class RegisterViewModel : PropertyChangedBase
    {
        private IUserRepository _userRepo;
        private ICommand registerCommand;
        private bool canExecute = true;

        public RegisterViewModel()
        {
            _userRepo = new UserRepository();
            RegisterCommand = new RelayCommand(Register, param => this.canExecute);
        }

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
                NotifyPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyPropertyChanged();
            }
        }

        private string _repeatPassword;
        public string RepeatPassword
        {
            get
            {
                return _repeatPassword;
            }
            set
            {
                _repeatPassword = value;
                NotifyPropertyChanged();
            }
        }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyPropertyChanged();
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                NotifyPropertyChanged();
            }
        }

        private string _cityName;
        public string CityName
        {
            get
            {
                return _cityName;
            }
            set
            {
                _cityName = value;
                NotifyPropertyChanged();
            }
        }

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand RegisterCommand
        {
            get
            {
                return registerCommand;
            }
            set
            {
                registerCommand = value;
            }
        }

        public async void Register(object obj)
        {
            if (!Password.Equals(RepeatPassword))
            {
                Message = "Ponovljena lozinka se ne poklapa";
                return;
            }
            Message = "Molimo pričekajte";
            string status = await _userRepo.Register(FirstName, LastName, Username, Password, Email, CityName);
            if (status.Equals("OK"))
            {
                Message = "Korisnik je registriran";
            }
            else
            {
                Message = status;
            }
        }
    }
}

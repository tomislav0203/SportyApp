using Models.DomainModels;
using Repository.Repos;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SportyDesktop.ViewModels;

namespace SportyDesktop.ViewModels
{
    public class LoginViewModel : PropertyChangedBase
    {
        private IUserRepository _userRepo;


        public LoginViewModel()
        {
            _userRepo = new UserRepository();
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

        public async Task<bool> Login()
        {
            Message = "Molimo pričekajte";
            bool success = await _userRepo.Login(Username, Password);
            if (!success)
            {
                Message = "Greska";
            }
            else
            {
                Message = "";
            }
            CurrentUser.username = Username;
            return success;
        }
    }
}

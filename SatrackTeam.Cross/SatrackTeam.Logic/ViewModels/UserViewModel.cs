using GalaSoft.MvvmLight.Command;
using SatrackTeam.Infrastructure.Contracts;
using SatrackTeam.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SatrackTeam.Logic.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public IApiService apiService { get; set; }
        public IDialogService dialogService { get; set; }

        public UserViewModel()
        {
            apiService = GetInstance<IApiService>();
        }

        private string username;

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private bool validUserName;

        public bool ValidUserName
        {
            get { return validUserName; }
            set { Set(ref validUserName, value); }
        }


        private bool validPassword;
        public bool ValidPassword
        {
            get { return validPassword; }
            set { Set(ref validPassword, value); }
        }
        public bool IsSessionStarted { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        async private void Login()
        {
            ValidPassword = false;
            ValidUserName = false;
            bool valid = true;
            if (string.IsNullOrWhiteSpace(UserName))
            {
                ValidUserName = true;
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                ValidPassword = true;
                valid = false;
            }
            if (valid)
            {
                var response = await apiService.ValidUser(ViewModelHelper.VMToModelUser(this));
                //if (response != null && response.Count > 0)
                if (true)
                {
                    IsSessionStarted = true;
                    var main = GetInstance<MainViewModel>();
                    main.NavigateTo("Main");
                }
                else
                {
                    await dialogService.ShowMessage("El usuario no existe", "Notificación");
                }

            }

        }
    }
}

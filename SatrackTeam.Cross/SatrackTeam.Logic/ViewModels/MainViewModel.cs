using SatrackTeam.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatrackTeam.Logic.ViewModels
{
    public class MainViewModel: ViewModelBase   
    {
        public INavigationService navigationService { get; set; }
        public UserViewModel userViewModel { get; set; }
        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }
        public MenuItemViewModel SelectedMenuItem { get; set; }
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { Set(ref isBusy, value); }
        }
        public MainViewModel()
        {
            navigationService = GetInstance<INavigationService>();
            userViewModel = new UserViewModel();
            LoadMenuItems();
        }
        private void LoadMenuItems()
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>();
            MenuItems.Add(new MenuItemViewModel()
            {
                Name = "Inicio",
                Type = "Main",
                Icon = "icon.png"
            });
            SelectedMenuItem = MenuItems[0];
            MenuItems.Add(new MenuItemViewModel()
            {
                Name = "Solicitudes",
                Type = "Request",
                Icon = "icon.png"
            });

        }

        internal void NavigateTo(string view)
        {
            navigationService.Navigate(view);
        }
    }
}

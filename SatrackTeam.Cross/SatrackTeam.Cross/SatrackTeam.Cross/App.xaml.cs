using SatrackTeam.Cross.Controls;
using SatrackTeam.Cross.Views;
using SatrackTeam.Cross.Views.Base;
using SatrackTeam.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SatrackTeam.Cross
{
    public partial class App : Application
    {
        public static IDependencyContainerService DependencyContainerService { get; set; }
        public static ExtendedNavigationPage Navigator { get; set; }
        public static IContext Context { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new LoginPage();
        }
        internal static void SetMainPage()
        {
            var MasterDetail = new MainPage();

            Navigator = new ExtendedNavigationPage(MasterDetail)
            {
                BarBackgroundColor = (Color)App.Current.Resources["ThemeColor"],
                BarTextColor = (Color)App.Current.Resources["ThemeFontColor"],
                Icon = "icon.png",
                Tint = Color.Black,

            };
            NavigationPage.SetBackButtonTitle(MasterDetail, "Atrás");
            NavigationPage.SetTitleIcon(MasterDetail, "icon.png");
            var masterpage = new MasterPage()
            {
                Master = new MenuPage(),
                Detail = Navigator,
            };

            Current.MainPage = masterpage;
        }
    }
}

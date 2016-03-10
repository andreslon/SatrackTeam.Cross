using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatrackTeam.Logic.ViewModels
{
    public class MainViewModel
    {
        public UserViewModel userViewModel { get; set; }

        public MainViewModel() {

            userViewModel = new UserViewModel
            {
                UserName = "Andreslon",
                Password = "12345"
            };


        }
    }
}

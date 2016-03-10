using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SatrackTeam.Domain.Models;
using SatrackTeam.Logic.ViewModels;

namespace SatrackTeam.Logic.Helpers
{
    public class ViewModelHelper
    {
        internal static User VMToModelUser(UserViewModel userViewModel)
        {
            return new User
            {
                username= userViewModel.UserName,
                password = userViewModel.Password,
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SatrackTeam.Domain.Models;
using System.Net.Http;
using Newtonsoft.Json;
using SatrackTeam.Infrastructure.Contracts;

namespace SatrackTeam.Infrastructure.Services
{
    public class ApiService : IApiService
    {
        public string serviceUrl { get; set; }

        public ApiService()
        {
            serviceUrl = "http://satrackteam.azurewebsites.net/tables/";
        }
        public async Task<List<User>> ValidUser(User user)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
                    var response = await client.GetAsync(new Uri(serviceUrl +"user"));
                    string result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<User>>(result).Where(x => x.username == user.username && x.password == user.password).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
       }
    }
}

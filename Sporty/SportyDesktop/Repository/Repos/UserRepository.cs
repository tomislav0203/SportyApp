using Models.DomainModels;
using Newtonsoft.Json.Linq;
using Repository.Util;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repos
{
    public class UserRepository : IUserRepository
    {
        private HttpHelper _context;

        public UserRepository()
        {
            _context = new HttpHelper();
            _context.setBaseUrl("http://sportfinderapi.azurewebsites.net");
        }

        public async Task<bool> Login(string username, string password)
        {
            JObject jsonObject = new JObject();
            jsonObject.Add("UserName", username);
            jsonObject.Add("Password", password);

            bool result = await _context.PostBool("/api/users/login", jsonObject);
            return result;
        }

        public async Task<string> Register(string firstName, string lastName, string userName, string password, string email, string cityName)
        {
            JObject jsonObject = new JObject();
            jsonObject.Add("UserName", userName);
            jsonObject.Add("Password", password);
            jsonObject.Add("FirstName", firstName);
            jsonObject.Add("LastName", lastName);
            jsonObject.Add("Email", email);
            jsonObject.Add("CityName", cityName);

            string result = await _context.PostString("/api/users/register", jsonObject);
            return result;
        }
    }
}

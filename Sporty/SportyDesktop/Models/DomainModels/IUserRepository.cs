using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DomainModels
{
    public interface IUserRepository
    {
        Task<bool> Login(string username, string password);
        Task<string> Register(string firstName, string lastName, string userName, string password, string email, string cityName);
    }
}

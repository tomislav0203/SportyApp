using Infrastructure.Domain;
using SportFinderApi.Models;
using System.Collections.Generic;

namespace Model.DomainModels
{
    public interface IUserRepository : IGenericRepository<User>
    {
        City FindCity(string name);
        IEnumerable<Sport> GetAllSports();
    }
}

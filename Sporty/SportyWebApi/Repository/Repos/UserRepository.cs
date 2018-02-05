using System.Collections.Generic;
using System.Linq;
using Infrastructure.Domain;
using Model.DomainModels;
using SportFinderApi.Models;

namespace Repository.Repos
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public City FindCity(string name)
        {
            return Session.Query<City>().Where(x => x.Name.ToLower().Equals(name.ToLower())).SingleOrDefault();
        }

        public IEnumerable<Sport> GetAllSports()
        {
            return Session.Query<Sport>();
        }

    }
}

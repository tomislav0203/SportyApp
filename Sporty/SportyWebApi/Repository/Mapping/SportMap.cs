using FluentNHibernate.Mapping;
using SportFinderApi.Models;

namespace Repository.Mapping
{
    public class SportMap : ClassMap<Sport>
    {
        public SportMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);

            Table("Sports");
        }
    }
}

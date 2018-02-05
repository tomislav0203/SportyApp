using FluentNHibernate.Mapping;
using SportFinderApi.Models;

namespace Repository.Mapping
{
    public class RatingMap : ClassMap<Rating>
    {
        public RatingMap()
        {
            Id(x => x.Id);
            Map(x => x.Value);

            References(x => x.Sport).Column("SportId").Not.LazyLoad();
            Table("Ratings");
        }
    }
}

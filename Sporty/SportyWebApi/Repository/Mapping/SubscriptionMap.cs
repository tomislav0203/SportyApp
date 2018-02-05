using FluentNHibernate.Mapping;
using SportFinderApi.Models;

namespace Repository.Mapping
{
    public class SubscriptionMap : ClassMap<Subscription>
    {
        public SubscriptionMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);

            References(x => x.User).Column("UserId").LazyLoad();
            References(x => x.City).Column("CityId").Not.LazyLoad();
            References(x => x.Sport).Column("SportId").Not.LazyLoad();
            Table("Subscriptions");
        }
    }
}

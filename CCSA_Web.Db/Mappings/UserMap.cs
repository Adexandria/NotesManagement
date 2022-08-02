using CCSA_Web.Domain.Models;
using FluentNHibernate.Mapping;

namespace CCSA_Web.Db.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.Username);
            Map(x => x.Password);
            Map(x => x.Email);
            
        }
    }
}

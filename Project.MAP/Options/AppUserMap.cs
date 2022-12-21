using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class AppUserMap:BaseMap<AppUser>
    {

        public AppUserMap()
        {
            ToTable("Uygulama Kullanıcıları");
            Property(x => x.UserName).HasColumnName("Kullanıcı Adı");
            Property(x => x.Password).HasColumnName("Kullanıcı Şifresi");

            //Relational Properties
            HasOptional(x => x.Profile).WithRequired(x => x.AppUser);

        }
    }
}

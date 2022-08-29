using KGGames.ENTİTİES.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.MAP.Options.EntityFrameWork
{
    public class UserMap : BaseMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.HasOne(u => u.UserProfile).WithOne(up => up.User).HasForeignKey<UserProfile>(up => up.UserID);
           
        }
    }
}

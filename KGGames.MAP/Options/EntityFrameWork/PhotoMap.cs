using KGGames.ENTİTİES.Models;
using KGGames.MAP.Options.EntityFrameWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using KGGames.ENTİTİES.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace KGGames.MAP.Options.EntityFramework
{
    public class PhotoMap : BaseMap<Photo>
    {
        public override void Configure(EntityTypeBuilder<Photo> builder)
        {
            base.Configure(builder);
        }
    }
}

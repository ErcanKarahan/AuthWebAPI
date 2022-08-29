using KGGames.ENTİTİES.Models;
using KGGames.MAP.Options.EntityFramework;
using KGGames.MAP.Options.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace KGGames.DAL.Concrete.EntityFrameWork.Context
{
    public class AppDbContext : DbContext
    {
        //DbSet's

        public DbSet<User>? Users { get; set; }
        public DbSet<UserProfile>? UserProfiles { get; set; }
        public DbSet<Photo>? Photos { get; set; }
        public DbSet<Category>? Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = ERCANKARAHAN; database = KGGames; uid = sa; pwd = Ak17041971; 
Trusted_Connection = True; Connect Timeout = 30; MultipleActiveResultSets = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserProfileMap());
            modelBuilder.ApplyConfiguration(new PhotoMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
        }
    }
}

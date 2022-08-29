using KGGames.CORE.DataAccess.Concrete;
using KGGames.DAL.Abstract;
using KGGames.DAL.Concrete.EntityFrameWork.Context;
using KGGames.ENTİTİES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.DAL.Concrete.EntityFrameWork.Repositories
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }
    }
}

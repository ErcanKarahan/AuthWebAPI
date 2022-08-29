using KGGames.CORE.DataAccess.Abstract;
using KGGames.ENTİTİES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.DAL.Abstract
{
    public interface IUserProfileRepository : IEntityRepository<UserProfile>
    {
    }
}

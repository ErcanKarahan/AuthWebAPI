using KGGames.CORE.DTO_s.User;
using KGGames.CORE.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.SERVİCE.Abstract
{
    public interface IUserProfileService
    {
        Task<IResult> UserProfileUpdate(UpdateUserProfileDTO updateUserProfileDTO);
    }
}

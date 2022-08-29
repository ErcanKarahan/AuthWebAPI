using KGGames.CORE.DTO_s.User;
using KGGames.CORE.JWT.Models;
using KGGames.CORE.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.SERVİCE.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<UserDTO>> Get(int userId);

        Task<IDataResult<UserDTO>> Get(UserLoginDTO userLoginDTO);

        Task<IResult> AddUser(UserAddDTO user);

        Task<IResult> RemoveUser(int id);

        Task<IDataResult<bool>> IsValid(UserLoginDTO userLoginDTO);

        Task<IDataResult<UserTokens>> LoginUser(UserLoginDTO userLoginDTO);
        Task<IResult> UpdateUserPassword(UpdateUserPasswordDTO updateUserPasswordDTO);
    }
}

using KGGames.CORE.DTO_s.User;
using KGGames.CORE.JWT.Models;
using KGGames.CORE.Utilities.Abstract;
using KGGames.ENTİTİES.Models;
using KGGames.SERVİCE.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace KGGames.Web.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userManager;
        private readonly IUserProfileService _userProfileManager;
        //private readonly IPhotoService _photoManager;

        public UserController(IUserService userManager, IUserProfileService userProfileManager, IPhotoService photoManager)
        {
            _userManager = userManager;
            _userProfileManager = userProfileManager;
            //_photoManager = photoManager;
        }





        //Purpose of this endpoint is meet to request that come from client side and create & give a JSON web token to client side.
        [HttpPost]
        public async Task<IDataResult<UserTokens>> Login([FromBody] UserLoginDTO userLoginDto)
        {
            return await _userManager.LoginUser(userLoginDto);
        }

        // GET: GetUser/id
        [/*Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]*/
        [HttpGet]
        public async Task<IDataResult<UserDTO>> GetUser(int userId)
        {
            //HttpRequest istek atanin token i alma. Request 
            return await _userManager.Get(userId);
        }

        //POST:AddUser and muss add a new UserRole to use the Property.
        //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<KGGames.CORE.Utilities.Abstract.IResult> AddUser(UserAddDTO userAddDto)
        {

            return await _userManager.AddUser(userAddDto);
        }


        //DELETE;DeleteUser
        //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete]
        public async Task<KGGames.CORE.Utilities.Abstract.IResult> DeleteUser(int id)
        {
            return await _userManager.RemoveUser(id);
        }

        [HttpPut]
        //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<KGGames.CORE.Utilities.Abstract.IResult> UpdateUserPassword(UpdateUserPasswordDTO updateUserPasswordDTO)
        {
            return await _userManager.UpdateUserPassword(updateUserPasswordDTO);
        }

        [HttpPut]
        //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<KGGames.CORE.Utilities.Abstract.IResult> UpdateUserProfile(UpdateUserProfileDTO updateUserProfileDTO)
        {
            return await _userProfileManager.UserProfileUpdate(updateUserProfileDTO);
        }

        //[HttpPost]
        //public async Task<KGGames.CORE.Utilities.Abstract.IDataResult<Photo>> getphoto(int id)
        //{
        //    return await _photoManager.GetPhotoAsync(id);
        //}
    }
}

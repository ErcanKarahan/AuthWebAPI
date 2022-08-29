using KGGames.CORE.DTO_s.User;
using KGGames.CORE.Utilities.Abstract;
using KGGames.CORE.Utilities.Concrete;
using KGGames.DAL.Abstract;
using KGGames.SERVİCE.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.SERVİCE.Concrete
{
    public class UserProfileManager : IUserProfileService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserProfileManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> UserProfileUpdate(UpdateUserProfileDTO updateUserProfileDTO)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(x => x.ID == updateUserProfileDTO.UserID, x => x.UserProfile);

            if (user != null)
            {
                if (user.UserProfile == null)
                    return new Result(CORE.Utilities.Enums.ResultStatus.Warning, "We have not found this user's profile.");

                var userProfile = user.UserProfile;

                user.Role = updateUserProfileDTO.Role == 0 ? user.Role : updateUserProfileDTO.Role;
                userProfile.FirstName = String.IsNullOrEmpty(updateUserProfileDTO.FirstName) ? user.UserProfile.FirstName : updateUserProfileDTO.FirstName;
                userProfile.LastName = String.IsNullOrEmpty(updateUserProfileDTO.LastName) ? user.UserProfile.LastName : updateUserProfileDTO.LastName;
                userProfile.Gender = updateUserProfileDTO.Gender == 0 ? user.UserProfile.Gender : updateUserProfileDTO.Gender;
                userProfile.Address = String.IsNullOrEmpty(updateUserProfileDTO.Address) ? user.UserProfile.Address : updateUserProfileDTO.Address;
                userProfile.MobilePhone = String.IsNullOrEmpty(updateUserProfileDTO.MobilePhone) ? user.UserProfile.MobilePhone : updateUserProfileDTO.MobilePhone;
                userProfile.WorkPhone = String.IsNullOrEmpty(updateUserProfileDTO.WorkPhone) ? user.UserProfile.WorkPhone : updateUserProfileDTO.WorkPhone;
                userProfile.HomePhone = String.IsNullOrEmpty(updateUserProfileDTO.HomePhone) ? user.UserProfile.HomePhone : updateUserProfileDTO.HomePhone;

                user.UserProfile = userProfile;

                var updatedUser = await _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.SaveAsync();

                if (updatedUser != null)
                    return new Result(CORE.Utilities.Enums.ResultStatus.Success, "User profile has been successfully updated.");
            }

            return new Result(CORE.Utilities.Enums.ResultStatus.Error, "User profile has not been updated. It has an error occurred while user profile updating.");
        }
    }
}

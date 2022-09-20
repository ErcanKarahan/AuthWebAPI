using AutoMapper;
using KGGames.CORE.DTO_s.User;
using KGGames.CORE.JWT.Models;
using KGGames.CORE.JWT;
using KGGames.CORE.Tools;
using KGGames.CORE.Utilities.Abstract;
using KGGames.CORE.Utilities.Concrete;
using KGGames.ENTİTİES.Models;
using KGGames.SERVİCE.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KGGames.DAL.Abstract;

namespace KGGames.SERVİCE.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public UserManager(IUnitOfWork unitOfWork, IMapper mapper, JwtSettings jwtSettings)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtSettings = jwtSettings;
        }

        public async Task<IResult> AddUser(UserAddDTO user)
        {
            user.UserInsertDTO.Password = DantexCrypt.Crypt(user.UserInsertDTO.Password);
            user.UserInsertDTO.ConfirmPassword = DantexCrypt.Crypt(user.UserInsertDTO.ConfirmPassword);

            if (await _unitOfWork.UserRepository.AnyAsync(x => x.Email == user.UserInsertDTO.Email))
            {
                return new Result(CORE.Utilities.Enums.ResultStatus.Warning, "This email address already exist on our database.");
            }

            var mappedUser = _mapper.Map<UserInsertDTO, User>(user.UserInsertDTO);
            var mappedUserProfile = _mapper.Map<UserProfileInsertDTO, UserProfile>(user.UserProfileInsertDTO);

            //string mailToBeSent = "Congratulations, your register process has been successfully completed. To activate your account please click this link https://localhost:7140r/Activation/" + mappedUser.ActivationCode;

            //MailSender.Send(user.UserInsertDTO.Email, body: mailToBeSent, subject: "Account Activation");



            if (!string.IsNullOrEmpty(user.UserProfileInsertDTO.FirstName) || !string.IsNullOrEmpty(user.UserProfileInsertDTO.LastName) || user.UserProfileInsertDTO.Gender != 0 || !string.IsNullOrEmpty(user.UserProfileInsertDTO.MobilePhone) || !string.IsNullOrEmpty(user.UserProfileInsertDTO.HomePhone) || !string.IsNullOrEmpty(user.UserProfileInsertDTO.WorkPhone) || !string.IsNullOrEmpty(user.UserProfileInsertDTO.Address))
            {
                mappedUser.UserProfile = mappedUserProfile;
            }

            await _unitOfWork.UserRepository.AddAsync(mappedUser);
            await _unitOfWork.SaveAsync();

            return new Result(CORE.Utilities.Enums.ResultStatus.Success, "User has been created successfully.");
        }

        public async Task<IDataResult<UserDTO>> Get(int userId)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(x => x.ID == userId);
            if (user != null)
            {
                var toBeSent = _mapper.Map<User, UserDTO>(user);
                return new DataResult<UserDTO>(CORE.Utilities.Enums.ResultStatus.Success, "Your request has been succesfully", toBeSent);
            }

            return new DataResult<UserDTO>(CORE.Utilities.Enums.ResultStatus.Error, "This user cannot find on database", null);
        }

        public async Task<IDataResult<UserDTO>> Get(UserLoginDTO userLoginDTO)
        {
            var cryptedEntryPassword = DantexCrypt.Crypt(userLoginDTO.Password);

            var user = await _unitOfWork.UserRepository.GetAsync(x => x.Email == userLoginDTO.Email && x.Password == cryptedEntryPassword,x=>x.UserProfile);

            if (user != null)
            {
                var sentUser = _mapper.Map<User, UserDTO>(user);
                return new DataResult<UserDTO>(CORE.Utilities.Enums.ResultStatus.Success, "Your request has been succesfully", sentUser);
            }

            return new DataResult<UserDTO>(CORE.Utilities.Enums.ResultStatus.Error, "This user cannot find on database", null);
        }

        public async Task<IDataResult<bool>> IsValid(UserLoginDTO userLoginDTO)
        {
            //First, we need to crypt input password from user.
            var cryptedEntryPassword = DantexCrypt.Crypt(userLoginDTO.Password);

            //After that we're checking database password with crypted input password.
            bool isValid = await _unitOfWork.UserRepository.AnyAsync(x => x.Email == userLoginDTO.Email && x.Password == cryptedEntryPassword);

            if (isValid)
                return new DataResult<bool>(CORE.Utilities.Enums.ResultStatus.Success, "There is a user on our database like this", true);

            return new DataResult<bool>(CORE.Utilities.Enums.ResultStatus.Error, "There is no user on our database like this", false);
        }

        public async Task<IDataResult<UserTokens>> LoginUser(UserLoginDTO userLoginDTO)
        {
            try
            {
                var Token = new UserTokens();
                var Valid = await IsValid(userLoginDTO);
                if (Valid.Data)
                {
                    var user = await Get(userLoginDTO);
                    Token = JwtHelpers.GenTokenKey(new UserTokens
                    {
                        EmailId = user.Data.Email,
                        GuidId = Guid.NewGuid(),
                        Role = user.Data.Role,
                        FirstName=user.Data.FirstName,
                        LastName=user.Data.LastName
                    }, _jwtSettings);
                }
                else
                {
                    return new DataResult<UserTokens>(CORE.Utilities.Enums.ResultStatus.Error, "Username or password are incorrect", null);
                }

                return new DataResult<UserTokens>(CORE.Utilities.Enums.ResultStatus.Success, "JWT Token has created successfully", Token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IResult> RemoveUser(int id)
        {
            var userToBeRemove = await _unitOfWork.UserRepository.GetAsync(x => x.ID == id, x => x.UserProfile);

            if (userToBeRemove != null)
            {
                await _unitOfWork.UserRepository.DeleteAsync(userToBeRemove);
                if (userToBeRemove.UserProfile != null)
                {
                    await _unitOfWork.UserProfileRepository.DeleteAsync(userToBeRemove.UserProfile);
                }

                await _unitOfWork.SaveAsync();

                return new Result(CORE.Utilities.Enums.ResultStatus.Success, "User has been deleted successfully.");
            }
            return new Result(CORE.Utilities.Enums.ResultStatus.Error, "User did not find on our database.");
        }

        public async Task<IResult> UpdateUserPassword(UpdateUserPasswordDTO updateUserPasswordDTO)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(x => x.ID == updateUserPasswordDTO.userId);

            if (user != null)
            {
                if (updateUserPasswordDTO.Password != updateUserPasswordDTO.ConfirmPassword)
                    return new Result(CORE.Utilities.Enums.ResultStatus.Warning, "Password and confirm password that you have entered was not be the same");

                if (DantexCrypt.DeCrypt(user.Password) == updateUserPasswordDTO.Password)
                    return new Result(CORE.Utilities.Enums.ResultStatus.Warning, "Password and old password that you've entered cannot be the same.");

                user.Password = DantexCrypt.Crypt(updateUserPasswordDTO.Password);
                user.ConfirmPassword = DantexCrypt.Crypt(updateUserPasswordDTO.ConfirmPassword);



                var updatedUser = await _unitOfWork.UserRepository.UpdateAsync(user);

                await _unitOfWork.SaveAsync();

                if (updatedUser != null)
                    return new Result(CORE.Utilities.Enums.ResultStatus.Success, "Password has been successfully updated.");

                return new Result(CORE.Utilities.Enums.ResultStatus.Error, "Password has not been updated. It has an error occurred while password updating.");
            }

            return new Result(CORE.Utilities.Enums.ResultStatus.Error, "The user has not been found on our database.");
        }
    }
}

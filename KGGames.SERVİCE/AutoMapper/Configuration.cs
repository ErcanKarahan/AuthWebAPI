using AutoMapper;
using KGGames.CORE.DTO_s.User;
using KGGames.ENTİTİES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.SERVİCE.AutoMapper
{
    public class Configuration : Profile
    {
        public Configuration()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<UserProfile, UserProfileInsertDTO>();
            CreateMap<UserProfileInsertDTO, UserProfile>();

            CreateMap<User, UserInsertDTO>();
            CreateMap<UserInsertDTO, User>();
        }
    }
}

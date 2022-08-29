using KGGames.CORE.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.CORE.DTO_s.User
{
    public class UpdateUserProfileDTO
    {

        public int UserID { get; set; }
        public UserRole Role { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender Gender { get; set; }
        public string? Address { get; set; }
        public string? MobilePhone { get; set; }
        public string? WorkPhone { get; set; }
        public string? HomePhone { get; set; }

    }
}

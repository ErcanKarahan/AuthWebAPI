using KGGames.CORE.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.CORE.DTO_s.User
{
    public class UserDTO
    {
        public string? Email { get; set; }
        public UserRole Role { get; set; }
        public bool UserActive { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}

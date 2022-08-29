using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.CORE.DTO_s.User
{
    public class UpdateUserPasswordDTO
    {
        public int userId { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }

    }
}

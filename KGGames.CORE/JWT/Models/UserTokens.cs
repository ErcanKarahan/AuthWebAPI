using KGGames.CORE.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.CORE.JWT.Models
{
    public class UserTokens
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Token { get; set; }
        public UserRole Role { get; set; }
        public TimeSpan Validaty { get; set; }
        public string? RefreshToken { get; set; }
        public int Id { get; set; }
        public string? EmailId { get; set; }
        public Guid GuidId { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}

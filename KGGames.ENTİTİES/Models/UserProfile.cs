using KGGames.CORE.Entities;
using KGGames.CORE.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.ENTİTİES.Models
{
    public class UserProfile:BaseEntity
    {
        public int? UserID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender Gender { get; set; }
        public string? Address { get; set; }
        public string? MobilePhone { get; set; }
        public string? WorkPhone { get; set; }
        public string? HomePhone { get; set; }


        //Relational Properties
        public virtual User? User { get; set; }
    }
}

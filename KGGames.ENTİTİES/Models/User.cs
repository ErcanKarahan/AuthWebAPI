using KGGames.CORE.Entities;
using KGGames.CORE.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KGGames.ENTİTİES.Models
{
    public class User:BaseEntity
    {
        
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public UserRole Role { get; set; }
        public Guid ActivationCode { get; set; }
        public bool Active { get; set; } // Reason of this property is for the activation check the whether user active or not.
        public User()
        {
            ActivationCode = Guid.NewGuid();
            Role = UserRole.User;
        }

        //Relational Properties
        public virtual UserProfile? UserProfile { get; set; }
        

    }
}

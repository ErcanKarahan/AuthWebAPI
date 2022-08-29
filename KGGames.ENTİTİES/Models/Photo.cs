using KGGames.CORE.Entities;

namespace KGGames.ENTİTİES.Models
{
    public class Photo:BaseEntity
    {
        public string ImagePath { get; set; }
        public int RealEstateId { get; set; }

        //Relational Properties
       
    }
}

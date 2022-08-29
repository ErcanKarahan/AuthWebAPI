using KGGames.CORE.DataAccess.Concrete;
using KGGames.DAL.Abstract;
using KGGames.DAL.Concrete.EntityFrameWork.Context;
using KGGames.ENTİTİES.Models;

namespace KGGames.DAL.Concrete.EntityFrameWork.Repositories
{
    public class PhotoRepository : EntityRepository<Photo>,IPhotoRepository
    {
        public PhotoRepository(AppDbContext context) : base(context)
        {
        }
    }
}

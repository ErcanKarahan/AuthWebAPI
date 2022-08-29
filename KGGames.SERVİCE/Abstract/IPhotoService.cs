using KGGames.CORE.Utilities.Abstract;
using KGGames.ENTİTİES.Models;
using KGGames.SERVİCE.Abstract;

namespace KGGames.SERVİCE.Abstract
{
    public interface IPhotoService
    {
        Task<IDataResult<Photo>> GetPhotoAsync(int id);
    }
}

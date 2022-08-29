using KGGames.CORE.Utilities.Abstract;
using KGGames.CORE.Utilities.Concrete;
using KGGames.DAL.Abstract;
using KGGames.ENTİTİES.Models;
using KGGames.SERVİCE.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.SERVİCE.Concrete
{
    public class PhotoManager : IPhotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PhotoManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<Photo>> GetPhotoAsync(int id)
        {
            var photo = await _unitOfWork.PhotoRepository.GetAsync(x => x.ID == id);

            if (photo != null)
            {
                return new DataResult<Photo>(CORE.Utilities.Enums.ResultStatus.Success, "your photo request from angular has been successfully", photo);
            }
            return new DataResult<Photo>(CORE.Utilities.Enums.ResultStatus.Error, "Fuck Off", null);
        }
    }
}

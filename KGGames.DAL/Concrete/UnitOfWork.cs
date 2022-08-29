using System;
using KGGames.DAL.Abstract;
using KGGames.DAL.Concrete.EntityFrameWork.Context;
using KGGames.DAL.Abstract;

namespace Immobilien.DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {


        private readonly AppDbContext _context;

        public IUserRepository UserRepository { get; }

        public IUserProfileRepository UserProfileRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public IPhotoRepository PhotoRepository { get; }

        

        public UnitOfWork(
            AppDbContext context,
            IUserRepository userRepository,
            IUserProfileRepository userProfileRepository,
            ICategoryRepository categoryRepository,
            IPhotoRepository photoRepository
            
            )
        {
            _context = context;
            UserRepository = userRepository;
            UserProfileRepository = userProfileRepository;
            CategoryRepository = categoryRepository;
            PhotoRepository = photoRepository;
           

        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}


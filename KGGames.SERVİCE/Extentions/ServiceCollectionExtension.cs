using AutoMapper;
using Immobilien.DAL.Concrete;
using KGGames.DAL.Abstract;
using KGGames.DAL.Concrete.EntityFrameWork.Context;
using KGGames.DAL.Concrete.EntityFrameWork.Repositories;
using KGGames.SERVİCE.Abstract;
using KGGames.SERVİCE.AutoMapper;
using KGGames.SERVİCE.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.SERVİCE.Extentions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<AppDbContext>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IUserProfileRepository, UserProfileRepository>();
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddScoped<IPhotoRepository, PhotoRepository>();
           

            serviceCollection.AddScoped<IUserService, UserManager>();
            serviceCollection.AddScoped<IUserProfileService, UserProfileManager>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IPhotoService, PhotoManager>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddCors();


            //AutoMapper Configuration. We are including configuration file that we have created.
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Configuration());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
            //AutoMapper Configration end.


            return serviceCollection;
        }
    }
}

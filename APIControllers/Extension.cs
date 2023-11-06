
using BussinessObjects.Models;
using Repositories.IRepositories;
using Repositories.RepositoryImpl;
using Services.IServices;
using Services.ServicesImpl;

namespace APIControllers
{
    public static class Extension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            return services.AddScoped<QuizletProjectContext>()
                .AddScoped<IStudySetRepository, StudySetRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserService, UserService>();
            //.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}

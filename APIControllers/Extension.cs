
using BussinessObjects.Models;
using Repositories.IRepository;
using Repositories.RepositoryImpl;

namespace APIControllers
{
    public static class Extension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            return services.AddScoped<QuizletProjectContext>()
                .AddScoped<IStudySetRepository, StudySetRepository>();
            //.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}

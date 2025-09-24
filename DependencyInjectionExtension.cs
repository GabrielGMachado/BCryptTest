using BCryptTest.Repository;

namespace BCryptTest
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
           
        }
    }
}

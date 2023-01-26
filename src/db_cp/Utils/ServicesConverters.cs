using Microsoft.Extensions.DependencyInjection;
using db_cp.ModelsConverters;

namespace db_cp.Utils
{
    public static class ProvideExtension
    {
        public static IServiceCollection AddDtoConverters(this IServiceCollection services)
        {
            services.AddTransient<AgentConverters>();
            services.AddTransient<ClubConverters>();
            services.AddTransient<CoachConverters>();
            services.AddTransient<PlayerConverters>();
            services.AddTransient<SquadConverters>();
            services.AddTransient<UserConverters>();

            return services;
        }
    }
}

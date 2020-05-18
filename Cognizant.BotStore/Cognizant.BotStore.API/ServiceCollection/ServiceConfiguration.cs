using Cognizant.BotStore.Core;
using Cognizant.BotStore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Cognizant.BotStore.API
{
    public static class ServiceConfiguration
    {
        public static void AddEfCoreRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericEfRepository<>), typeof(GenericEfRepository<>));
            services.AddScoped(typeof(ITeamDetailsRepository), typeof(TeamDetailsRepository));
            services.AddScoped(typeof(IAttributeDetailsRepository), typeof(AttributeDetailsRepository));
            services.AddScoped(typeof(IBotAssignmentRepository), typeof(BotAssignmentRepository));
            services.AddScoped(typeof(IBotAttributeMasterRepository), typeof(BotAttributeMasterRepository));
            services.AddScoped(typeof(IBotIntendMasterRepository), typeof(BotIntendMasterRepository));
            services.AddScoped(typeof(IBotMasterRepository), typeof(BotMasterRepository));
            services.AddScoped(typeof(IBotSkillMasterRepository), typeof(BotSkillMasterRepository));
            services.AddScoped(typeof(IIntendDetailsRepository), typeof(IntendDetailsRepository));
            services.AddScoped(typeof(IBotImageDetailsRepository), typeof(BotImageDetailsRepository));
        }
        public static void AddEntityServices(this IServiceCollection services)
        {
            services.AddScoped<IAttributeDetailsService, AttributeDetailsService>();
            services.AddScoped<IBotAssignmentService, BotAssignmentService>();
            services.AddScoped<IBotAttributeMasterService, BotAttributeMasterService>();
            services.AddScoped<IBotIntendMasterService, BotIntendMasterService>();
            services.AddScoped<IBotMasterService, BotMasterService>();
            services.AddScoped<IBotSkillMasterService, BotSkillMasterService>();
            services.AddScoped<IIntendDetailsService, IntendDetailsService>();
            services.AddScoped<ITeamDetailsService, TeamDetailsService>();
            services.AddScoped<IBotListService, BotListService>();
            services.AddScoped<IBotImageDetailsService, BotImageDetailsService>();
        }
    }
}

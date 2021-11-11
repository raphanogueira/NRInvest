using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NRInvest.Api.Pipelines;
using NRInvest.Domain.Commands.Accounts.AddNewAccount;
using NRInvest.Domain.Contracts.Authentication;
using NRInvest.Domain.Contracts.Repositories;
using NRInvest.Domain.Models;
using NRInvest.Domain.Profiles;
using NRInvest.Domain.Services;
using NRInvest.Infrastructure.MongoDB.Repositories;

namespace NRInvest.Api.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection InjectSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSettings<MongoSettings>(configuration);
            services.AddSettings<JwtSettings>(configuration);

            return services;
        }

        public static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IBaseMongoRepository<>), typeof(BaseMongoRepository<>));

            return services;
        }

        public static IServiceCollection InjectDomain(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddNewAccountCommand).Assembly);
            services.AddAutoMapper(typeof(AccountProfile).Assembly);
            services.AddValidatorsFromAssembly(typeof(AddNewAccountCommandValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }

        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.
                AddTransient<IAuthenticationService, AuthenticationService>();

            return services;
        }

        public static IServiceCollection AddSettings<T>(this IServiceCollection services, IConfiguration configuration) where T : Settings, new()
        {
            return services.Configure<T>(configuration.GetSection(typeof(T).Name))
                    .AddSingleton(serviceCollections => serviceCollections.GetRequiredService<IOptions<T>>().Value);
        }
    }
}
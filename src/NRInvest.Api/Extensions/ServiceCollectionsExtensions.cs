using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NRInvest.Api.Pipelines;
using NRInvest.Domain.Commands.Accounts.AddNewAccount;
using NRInvest.Domain.Contracts.Repositories;
using NRInvest.Domain.Models;
using NRInvest.Domain.Profiles;
using NRInvest.Infrastructure.MongoDB.Repositories;

namespace NRInvest.Api.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoSettings>(
                configuration.GetSection(nameof(MongoSettings)));

            services.AddSingleton(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoSettings>>().Value);

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IBaseMongoRepository<>), typeof(BaseMongoRepository<>));

            return services;
        }

        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddNewAccountCommand).Assembly);
            services.AddAutoMapper(typeof(AccountProfile).Assembly);
            services.AddValidatorsFromAssembly(typeof(AddNewAccountCommandValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
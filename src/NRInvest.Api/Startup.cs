using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NRInvest.Domain.Commands.Accounts.AddNewAccount;
using NRInvest.Domain.Contracts.Repositories;
using NRInvest.Domain.Models;
using NRInvest.Domain.Profiles;
using NRInvest.Infrastructure.MongoDB.Repositories;

namespace NRInvest.Api
{
    public sealed class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMediatR(typeof(AddNewAccountCommand).Assembly);
            services.AddAutoMapper(typeof(AccountProfile).Assembly);
            services.AddSwaggerGen();

            services.Configure<MongoSettings>(
                Configuration.GetSection(nameof(MongoSettings)));

            services.AddSingleton(sp => sp.GetRequiredService<IOptions<MongoSettings>>().Value);
            services.AddSingleton<IAccountRepository, AccountRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

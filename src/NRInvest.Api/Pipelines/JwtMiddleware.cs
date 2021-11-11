using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using NRInvest.Domain.Contracts.Repositories;
using NRInvest.Domain.Entities;
using NRInvest.Domain.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRInvest.Api.Pipelines
{
    public sealed class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtSettings _jwtSettings;
        private readonly IBaseMongoRepository<Account> _accountRepository;

        public JwtMiddleware(RequestDelegate next,
            JwtSettings jwtSettings,
            IBaseMongoRepository<Account> accountRepository)
        {
            _next = next;
            _jwtSettings = jwtSettings;
            _accountRepository = accountRepository;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();

            if (token != null)
                await AttachUserContextAsync(context, token);

            await _next(context);
        }

        private async Task AttachUserContextAsync(HttpContext context, string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "jti").Value);

            context.Items["User"] = await _accountRepository.GetByIdAsync(userId);
        }
    }
}

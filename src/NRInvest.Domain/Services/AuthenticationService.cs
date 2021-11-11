using Microsoft.IdentityModel.Tokens;
using NRInvest.Domain.Contracts.Authentication;
using NRInvest.Domain.Entities;
using NRInvest.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NRInvest.Domain.Services
{
    public sealed class AuthenticationService : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public string GenerateToken(Account account)
        {
            var base64Key = Encoding.ASCII.GetBytes(_jwtSettings.Key);

            var securityKey = new SymmetricSecurityKey(base64Key);

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials,
                claims: new List<Claim>() { new Claim("jti", account.Id.ToString()) }
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
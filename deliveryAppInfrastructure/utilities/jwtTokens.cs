using deliveryAppCore.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace deliveryAppInfrastructure.utilities
{
    public class jwtTokens
    {
        private IConfiguration _config;
        public jwtTokens(IConfiguration config)
        {
            _config = config;
        }

        public jwtTokens()
        {
        }

        public String GenerateJSONWebToken(User user)
        {
            string key = ConfigHelper.GetConfig<string>("Jwt:Key");
            string Issuer = ConfigHelper.GetConfig<string>("Jwt:Issuer");
            string Time = ConfigHelper.GetConfig<string>("Jwt:Time");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            int time = Convert.ToInt32(Time);

            var claims = new[] {
                            new Claim("user", user.User1),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())};

            var token = new JwtSecurityToken(Issuer, Issuer, claims, expires: DateTime.Now.AddMinutes(time), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}

using FastCoding.Framework;
using FastCoding.Framework.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebApplication1.Api
{
    public class AuthorizationController : BaseController
    {

        [AllowAnonymous, HttpPost("/api/auth/token")]
        public TokenResult Login(string name, string pass)
        {
            if (name == "abc" && pass == "123456")
            {
                var claims = new[] {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, "test@123.com"),
                    new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.Now.AddSeconds(Convert.ToInt32(Global.Configuration.GetSection("JWT")["Expires"]))).ToUnixTimeSeconds()}"),
                    new Claim(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}")
                };
                return Utils.GetToken(claims);
            }
            else
            {
                throw new CustomeException("账号或密码错误", StatusCodes.Status404NotFound);
            }
        }
    }
}

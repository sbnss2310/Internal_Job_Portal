using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthSvc.Controllers
{
    public class AuthController : ApiController
    {
        private string GenerateJWT(string userName, string role, string key)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,userName),
                new Claim(ClaimTypes.Role,role)
            };
            var token = new JwtSecurityToken(issuer: "https://www.animewasaikyo.com", audience: "https://www.animewasaikyo.com", expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials, claims: claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }





        [HttpGet]
        public IHttpActionResult GetToken(string userName, string role, string key)
        {
            string token = GenerateJWT(userName, role, key);
            return Ok(token);
        }
    }
}

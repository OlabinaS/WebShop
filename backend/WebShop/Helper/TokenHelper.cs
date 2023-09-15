using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebShop.Helper.Interfaces;
using WebShop.Models;

namespace WebShop.Helper
{
	public class TokenHelper : ITokenHelper
	{
        string _key;
		public string GetToken(Usr user)
		{
            List<Claim> claims = new List<Claim>();

            if (user.role == "Admin")
            {

                claims.Add(new Claim(ClaimTypes.Role, user.role));
                claims.Add(new Claim("role", user.role));
                claims.Add(new Claim("id", user.Id.ToString()));
                claims.Add(new Claim("username", user.Username));
                claims.Add(new Claim("logKind", "form"));
            }
            else if (user.role == "Seller")
            {
                claims.Add(new Claim(ClaimTypes.Role, user.role));
                claims.Add(new Claim("role", user.role));
                claims.Add(new Claim("id", user.Id.ToString()));
                claims.Add(new Claim("username", user.Username));
                claims.Add(new Claim("status", user.verification.ToString()));
                claims.Add(new Claim("logKind", "form"));

            }
            else if (user.role == "Customer")
            {
                claims.Add(new Claim(ClaimTypes.Role, user.role));
                claims.Add(new Claim("role", user.role));
                claims.Add(new Claim("id", user.Id.ToString()));
                claims.Add(new Claim("username", user.Username));
                claims.Add(new Claim("logKind", "form"));

            }

            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:44326",
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: signinCredentials
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
	}
}

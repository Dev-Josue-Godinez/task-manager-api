using Microsoft.IdentityModel.Tokens;
using Models;
using Models.Dtos;
using Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Task_Manager_API.OAuth
{
    public class Authorization
    {
        public static readonly Func<HttpContext, UserCredential, DBContext, WebApplicationBuilder, Response<Token>> OAuthGenerator =
            (context, userCredential, dbContext, builder) =>
            {
                using (dbContext)
                {
                    Login? user = dbContext.Logins.Where(login => login.Email.Equals(userCredential.Email) && login.Password.Equals(userCredential.Password)).FirstOrDefault();
                    if(user is null)
                    {
                        return new Response<Token>
                        {
                            Status = new HttpStatus
                            {
                                StatusCode = HttpStatusCode.BadRequest,
                                StatusMessage = "Credenciales Incorrectas",
                            },
                            Data = null
                        };
                    }
                    
                    return new Response<Token>
                    {
                        Status = new HttpStatus
                        {
                            StatusCode = HttpStatusCode.OK,
                            StatusMessage = null,
                        },
                        Data = GenerateToken(user)
                    };
                }
            };

        private static Token GenerateToken(Login user)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes("tcwXdgJaRmFfe9Wkjmi3q21VcaFzuv8s");

                Dictionary<string, object> claims = new Dictionary<string, object>();
                claims.Add(ClaimTypes.Name.ToString(), user.Name);
                claims.Add(ClaimTypes.Email.ToString(), user.Email);

                SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Claims = claims
                };
                SecurityToken token = tokenHandler.CreateToken(securityTokenDescriptor);

                return new Token
                {
                    Access_Token = tokenHandler.WriteToken(token),
                    Expire_Token = (DateTime)securityTokenDescriptor.Expires,
                    Email = user.Email,
                    UserId = user.Id,
                };
            }
            catch
            {
                throw;
            }
        }
    }
}

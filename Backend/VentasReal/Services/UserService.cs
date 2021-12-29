using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VentasReal.Models;
using VentasReal.Models.Common;
using VentasReal.Models.Request;
using VentasReal.Models.Response;
using VentasReal.Tools;

namespace VentasReal.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserResponse Auth(AuthRequest authRequest)
        {
            UserResponse userResponse = new UserResponse();

            using (var db = new VentaRealContext())
            {
                
                string spassword = Encrypt.GetSHA256(authRequest.Password);

                var usuario = db.Usuarios.Where(d => 
                d.Email == authRequest.Email && d.Password == spassword).
                    FirstOrDefault();
                if (usuario == null) return null;
                userResponse.Email = usuario.Email;
                userResponse.Token = this.GetToken(usuario);
            }
            return userResponse;            
        }

        private string GetToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Email, usuario.Email)
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

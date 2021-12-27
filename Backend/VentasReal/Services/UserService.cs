using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasReal.Models;
using VentasReal.Models.Request;
using VentasReal.Models.Response;
using VentasReal.Tools;

namespace VentasReal.Services
{
    public class UserService : IUserService
    {
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
            }
            return userResponse;            
        }
    }
}

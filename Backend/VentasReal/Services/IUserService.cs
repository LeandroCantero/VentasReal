using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasReal.Models.Request;
using VentasReal.Models.Response;

namespace VentasReal.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest authRequest);
    }
}

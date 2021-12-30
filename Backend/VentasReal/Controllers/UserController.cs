using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentasReal.Models.Request;
using VentasReal.Models.Response;
using VentasReal.Services;

namespace VentasReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Auth([FromBody] AuthRequest authRequest)
        {
            Respuesta respuesta = new Respuesta();

            var userResponse = _userService.Auth(authRequest);

            if (userResponse == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Usuario o contraseña incorrectos";
                return BadRequest(respuesta);
            }

            respuesta.Exito = 1;
            respuesta.Data = userResponse;

            return Ok(respuesta);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentasReal.Models.Request;

namespace VentasReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControler : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Auth([FromBody] AuthRequest model)
        {
            return Ok(model);
        }
    }
}

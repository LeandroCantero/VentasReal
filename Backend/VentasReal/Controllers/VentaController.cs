using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VentasReal.Models;
using VentasReal.Models.Request;
using VentasReal.Models.Response;
using VentasReal.Services;

namespace VentasReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {
        private IVenta _venta;

        public VentaController(IVenta venta) {
            this._venta = venta;
        }

        [HttpPost]
        public IActionResult Add(VentaRequest ventaRequest)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                _venta.Add(ventaRequest);
                respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
                
            }

            return Ok(respuesta);
        }
        
    }
}

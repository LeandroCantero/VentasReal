using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VentasReal.Models;
using VentasReal.Models.Request;
using VentasReal.Models.Response;

namespace VentasReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(VentaRequest ventaRequest)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                using(VentaRealContext db = new VentaRealContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {

                        
                            var venta = new Ventum();
                            venta.Total = ventaRequest.Conceptos.Sum(d => d.Cantidad * d.PrecioUnitario);
                            venta.Fecha = DateTime.Now;
                            venta.IdCliente = ventaRequest.IdCliente;
                            db.Venta.Add(venta);
                            db.SaveChanges();

                            foreach (var ventaConcepto in ventaRequest.Conceptos)
                            {
                                var concepto = new Models.Concepto();
                                concepto.Cantidad = ventaConcepto.Cantidad;
                                concepto.IdProducto = ventaConcepto.IdProducto;
                                concepto.PrecioUnitario = ventaConcepto.PrecioUnitario;
                                concepto.Importe = ventaConcepto.Importe;
                                concepto.IdVenta = venta.Id;
                                db.Conceptos.Add(concepto);
                                db.SaveChanges();
                            }

                            transaction.Commit();
                            respuesta.Exito = 1;

                        }
                        catch(Exception)
                        {
                            transaction.Rollback();
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.InnerException.Message;
                
            }

            return Ok(respuesta);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasReal.Models;
using VentasReal.Models.Request;

namespace VentasReal.Services
{
    public class VentaService : IVenta
    {
        public void Add(VentaRequest ventaRequest)
        {
           
            using (VentaRealContext db = new VentaRealContext())
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
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw new Exception("Error in the insertion");
                    }
                }

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VentasReal.Models.Request
{
    public class VentaRequest
    {
        [Required]
        [ExisteCliente(ErrorMessage = "Client doesn't exist")]
        public int IdCliente { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "There should be concepts")]
        public List<Concepto> Conceptos { get; set; }
    
        public VentaRequest()
        {
            this.Conceptos = new List<Concepto>();
        }
    }

    public class Concepto
    {
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public int IdProducto { get; set; }
    }

    public class ExisteCliente : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int idCliente = (int)value;
            using (var db = new Models.VentaRealContext())
            {
                if (db.Clientes.Find(idCliente) == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

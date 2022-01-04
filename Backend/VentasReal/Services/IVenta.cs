using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasReal.Models.Request;

namespace VentasReal.Services
{
    public interface IVenta
    {
        public void Add(VentaRequest ventaRequest);
    }
}

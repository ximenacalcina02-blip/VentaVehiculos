using System.Collections.Generic;

namespace VentaDeVehiculo.Models
{
    public class VentaRequest
    {
        public Venta Venta { get; set; } = new Venta();
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
        public int CantidadCuotas { get; set; }
    }
}
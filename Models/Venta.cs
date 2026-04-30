using System;

namespace VentaDeVehiculo.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public decimal TotalVenta { get; set; }
        
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public int SucursalId { get; set; }
        public Sucursal? Sucursal { get; set; }
    }
}
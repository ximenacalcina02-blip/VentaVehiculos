using System;

namespace VentaDeVehiculo.Models
{
    public class Cuotas
    {
        public int Id { get; set; }
        public int NumeroCuota { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Pagado { get; set; }

        public int VentaId { get; set; }
        public Venta? Venta { get; set; }
    }
}
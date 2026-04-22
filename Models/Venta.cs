using System.ComponentModel.DataAnnotations.Schema;

namespace VentaDeVehiculo.Entidades
{
    public class Venta
    {
        public Guid Id { get; set; }

        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public Guid VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }

        public DateTime Fecha { get; set; }
    }
}
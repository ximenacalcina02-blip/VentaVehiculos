namespace VentaDeVehiculo.Models
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

        public int VentaId { get; set; }
        public Venta? Venta { get; set; }

        public int VehiculoId { get; set; }
        public Vehiculo? Vehiculo { get; set; }
    }
}
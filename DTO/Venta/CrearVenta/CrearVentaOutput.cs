namespace VentaDeVehiculo.DTO.Venta.CrearVenta
{
    public class CrearVentaOutput
    {
        public Guid Id { get; set; }
        public string Cliente { get; set; }
        public string Vehiculo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
namespace VentaDeVehiculo.DTO.Venta.ListarVentas
{
    public class ListarVentasOutput
    {
        public Guid Id { get; set; }
        public string Cliente { get; set; }
        public string Vehiculo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
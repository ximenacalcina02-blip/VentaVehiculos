namespace VentaDeVehiculo.DTO.Vehiculo.ListarVehiculos
{
    public class ListarVehiculosOutput
    {
        public Guid Id { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public decimal Precio { get; set; }
    }
}
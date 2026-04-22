namespace VentaDeVehiculo.DTO.Vehiculo.AgregarVehiculo
{
    public class AgregarVehiculoOutput
    {
        public Guid Id { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public decimal Precio { get; set; }
    }
}
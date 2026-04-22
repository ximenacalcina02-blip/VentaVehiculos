namespace VentaDeVehiculo.Entidades
{
    public class Vehiculo
    {
        public Guid Id { get; set; }

        public string? Marca { get; set; }

        public string? Modelo { get; set; }

        public decimal Precio { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
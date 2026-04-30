namespace VentaDeVehiculo.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public int Anio { get; set; }
        public decimal Precio { get; set; }
        public int MarcaId { get; set; }
        public Marca? Marca { get; set; }
    }
}
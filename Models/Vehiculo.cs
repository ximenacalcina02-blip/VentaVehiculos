public class Vehiculo
{
    public int Id { get; set; }
    public string Marca { get; set; } = "";
    public string Modelo { get; set; } = "";
    public double Precio { get; set; }

    public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
}
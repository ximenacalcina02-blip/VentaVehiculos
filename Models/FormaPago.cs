using VentaDeVehiculo.Entidades;
public class FormaPago
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public List<Venta> Ventas { get; set; } = new List<Venta>();
}

using VentaDeVehiculo.Entidades;
public class Cuota
{
    public int Id { get; set; }
    public int VentaId { get; set; }
    public Venta Venta { get; set; } = new();
    public int NumeroCuota { get; set; }
    public DateTime FechaPago { get; set; }
    public DateTime? FechaPagoReal { get; set; }
    public double Monto { get; set; }
    public bool Pagado { get; set; }
}
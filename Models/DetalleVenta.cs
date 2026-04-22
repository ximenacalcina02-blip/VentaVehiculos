
using VentaDeVehiculo.Entidades;
public class DetalleVenta
{
    public int VentaId { get; set; }
    public Venta Venta { get; set; } = new Venta();

    public int VehiculoId { get; set; }
    public Vehiculo Vehiculo { get; set; } = new Vehiculo();

    public int Cantidad { get; set; }
}
public class Venta
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = new Cliente();

    public int VendedorId { get; set; }
    public Vendedor Vendedor { get; set; } = new Vendedor();
    public int FormaPagoId { get; set; }
    public FormaPago FormaPago { get; set; } = new FormaPago();
    public List<Cuota> Cuotas { get; set; } = new List<Cuota>();

    public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
}
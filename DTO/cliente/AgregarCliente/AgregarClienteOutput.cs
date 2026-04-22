namespace VentaDeVehiculo.DTO.Cliente.AgregarCliente
{
    public class AgregarClienteOutput
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public int Ci { get; set; }
        public string? Extension { get; set; }
    }
}
namespace VentaDeVehiculo.Entidades
{
    public class Cliente
    {
        public Guid Id { get; set; }

        public string? Nombre { get; set; }

        public int Ci { get; set; }

        public string? Extension { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using VentaDeVehiculo.Entidades;

namespace VentaDeVehiculo.Data
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
    }
}
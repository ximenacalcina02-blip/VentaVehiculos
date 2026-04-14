using Microsoft.EntityFrameworkCore;

public class DbContexto : DbContext
{
    public DbContexto(DbContextOptions<DbContexto> options) : base(options) {}

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Vendedor> Vendedores { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    public DbSet<FormaPago> FormasPago { get; set; }
    public DbSet<Cuota> Cuotas { get; set; }
    public DbSet<DetalleVenta> DetalleVentas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<DetalleVenta>()
            .HasKey(d => new { d.VentaId, d.VehiculoId });

        // Relaciones
        modelBuilder.Entity<DetalleVenta>()
            .HasOne(d => d.Venta)
            .WithMany(v => v.Detalles)
            .HasForeignKey(d => d.VentaId);

        modelBuilder.Entity<DetalleVenta>()
            .HasOne(d => d.Vehiculo)
            .WithMany(v => v.Detalles)
            .HasForeignKey(d => d.VehiculoId);
    }
}
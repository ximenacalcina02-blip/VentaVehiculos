using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentaDeVehiculo.Data;
using VentaDeVehiculo.DTO.Venta.CrearVenta;
using VentaDeVehiculo.DTO.Venta.ListarVentas;
using VentaDeVehiculo.Entidades;

namespace VentaDeVehiculo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly DbContexto _contexto;

        public VentasController(DbContexto contexto)
        {
            _contexto = contexto;
        }

       
        [HttpGet]
        public async Task<ActionResult<List<ListarVentasOutput>>> GetVentas()
        {
            var ventas = await _contexto.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Vehiculo)
                .Select(v => new ListarVentasOutput
                {
                    Id = v.Id,
                    Cliente = v.Cliente.Nombre,
                    Vehiculo = v.Vehiculo.Marca + " " + v.Vehiculo.Modelo,
                    Fecha = v.Fecha
                })
                .ToListAsync();

            return Ok(ventas);
        }

       
        [HttpPost]
        public async Task<ActionResult<CrearVentaOutput>> CrearVenta([FromBody] CrearVentaInput input)
        {
          
            var cliente = await _contexto.Clientes.FindAsync(input.ClienteId);
            if (cliente == null)
                return BadRequest("Cliente no existe");

            var vehiculo = await _contexto.Vehiculos.FindAsync(input.VehiculoId);
            if (vehiculo == null)
                return BadRequest("Vehiculo no existe");

            var venta = new Venta
            {
                Id = Guid.NewGuid(),
                ClienteId = input.ClienteId,
                VehiculoId = input.VehiculoId,
                Fecha = DateTime.UtcNow
            };

            _contexto.Ventas.Add(venta);
            await _contexto.SaveChangesAsync();

            return Ok(new CrearVentaOutput
            {
                Id = venta.Id,
                Cliente = cliente.Nombre,
                Vehiculo = vehiculo.Marca + " " + vehiculo.Modelo,
                Fecha = venta.Fecha
            });
        }
    }
}
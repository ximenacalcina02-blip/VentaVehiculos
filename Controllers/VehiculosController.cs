using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentaDeVehiculo.Data;
using VentaDeVehiculo.DTO.Vehiculo.AgregarVehiculo;
using VentaDeVehiculo.DTO.Vehiculo.ListarVehiculos;
using VentaDeVehiculo.Entidades;

namespace VentaDeVehiculo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculosController : ControllerBase
    {
        private readonly DbContexto _contexto;

        public VehiculosController(DbContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListarVehiculosOutput>>> GetVehiculos()
        {
            var lista = await _contexto.Vehiculos
                .Select(v => new ListarVehiculosOutput
                {
                    Id = v.Id,
                    Marca = v.Marca,
                    Modelo = v.Modelo,
                    Precio = v.Precio
                })
                .ToListAsync();

            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<AgregarVehiculoOutput>> CrearVehiculo([FromBody] AgregarVehiculoInput input)
        {
            var vehiculo = new Vehiculo
            {
                Id = Guid.NewGuid(),
                Marca = input.Marca,
                Modelo = input.Modelo,
                Precio = input.Precio,
                FechaCreacion = DateTime.UtcNow
            };

            _contexto.Vehiculos.Add(vehiculo);
            await _contexto.SaveChangesAsync();

            return Ok(new AgregarVehiculoOutput
            {
                Id = vehiculo.Id,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Precio = vehiculo.Precio
            });
        }
    }
}
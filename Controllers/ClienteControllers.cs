using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentaDeVehiculo.Data;
using VentaDeVehiculo.DTO.Cliente.AgregarCliente;
using VentaDeVehiculo.DTO.Cliente.ListarClientes;
using VentaDeVehiculo.DTO.Cliente.ObtenerCliente;
using VentaDeVehiculo.DTO.Cliente.EliminarCliente;
using VentaDeVehiculo.Entidades;

namespace VentaDeVehiculo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly DbContexto _contexto;

        public ClientesController(DbContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListarClientesOutput>>> GetClientes()
        {
            var clientes = await _contexto.Clientes
                .Select(x => new ListarClientesOutput
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Ci = x.Ci
                })
                .ToListAsync();

            return Ok(clientes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ObtenerClienteOutput>> GetCliente(Guid id)
        {
            var cliente = await _contexto.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            return Ok(new ObtenerClienteOutput
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Ci = cliente.Ci,
                Extension = cliente.Extension
            });
        }


        [HttpPost]
        public async Task<ActionResult<AgregarClienteOutput>> CrearCliente([FromBody] AgregarClienteInput input)
        {
            var cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nombre = input.Nombre,
                Ci = input.Ci,
                Extension = input.Extension,
                FechaCreacion = DateTime.UtcNow,
                FechaUltimaModificacion = DateTime.UtcNow
            };

            _contexto.Clientes.Add(cliente);
            await _contexto.SaveChangesAsync();

            return Ok(new AgregarClienteOutput
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Ci = cliente.Ci,
                Extension = cliente.Extension
            });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<EliminarClienteOutput>> DeleteCliente(Guid id)
        {
            var cliente = await _contexto.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            _contexto.Clientes.Remove(cliente);
            await _contexto.SaveChangesAsync();

            return Ok(new EliminarClienteOutput
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre
            });
        }
    }
}
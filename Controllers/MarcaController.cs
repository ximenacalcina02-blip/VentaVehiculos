using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentaDeVehiculo.Data;
using VentaDeVehiculo.Models;

namespace VentaDeVehiculo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly DbContexto _contexto;

        public MarcasController(DbContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas()
        {
            return await _contexto.Marcas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Marca>> PostMarca(Marca marca)
        {
            _contexto.Marcas.Add(marca);
            await _contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMarcas), new { id = marca.Id }, marca);
        }
    }
}
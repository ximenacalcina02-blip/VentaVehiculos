using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentaDeVehiculo.Data;
using VentaDeVehiculo.Models;

namespace VentaDeVehiculo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly DbContexto _contexto;

        public SucursalesController(DbContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sucursal>>> GetSucursales()
        {
            return await _contexto.Sucursales.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<Sucursal>> PostSucursal(Sucursal sucursal)
        {
            _contexto.Sucursales.Add(sucursal);
            await _contexto.SaveChangesAsync();
            return Ok(sucursal);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentaDeVehiculo.Data;
using VentaDeVehiculo.Models;

namespace VentaDeVehiculo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly DbContexto _contexto;

        public VentasController(DbContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarVenta([FromBody] VentaRequest request)
        {

            if (request == null || request.Venta == null)
            {
                return BadRequest("La información de la venta es obligatoria.");
            }


            _contexto.Ventas.Add(request.Venta);
            await _contexto.SaveChangesAsync(); 

            if (request.Detalles != null && request.Detalles.Count > 0)
            {
                foreach (var item in request.Detalles)
                {
                    item.VentaId = request.Venta.Id; 
                    _contexto.DetallesVentas.Add(item);
                }
            }


            if (request.CantidadCuotas > 0)
            {

                decimal montoCuota = request.Venta.TotalVenta / request.CantidadCuotas;

                for (int i = 1; i <= request.CantidadCuotas; i++)
                {
                    var nuevaCuota = new Cuotas
                    {
                        VentaId = request.Venta.Id,
                        NumeroCuota = i,
                        Monto = montoCuota,
                        FechaVencimiento = DateTime.Now.AddMonths(i),
                        Pagado = false
                    };
                    _contexto.Cuotas.Add(nuevaCuota);
                }
            }

            await _contexto.SaveChangesAsync();

            return Ok(new { 
                mensaje = "Venta registrada con éxito", 
                idVenta = request.Venta.Id,
                detallesRegistrados = request.Detalles?.Count ?? 0,
                cuotasGeneradas = request.CantidadCuotas
            });
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
            return await _contexto.Ventas.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVenta(int id)
        {
            var venta = await _contexto.Ventas.FindAsync(id);
            if (venta == null) return NotFound();
            return venta;
        }
    }
}
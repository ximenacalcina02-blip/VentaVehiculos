using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")] 
[ApiController]
public class VentasController : ControllerBase
{
    private readonly DbContexto _context;


    public VentasController(DbContexto context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
    {
        return await _context.Ventas.ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Venta>> GetVenta(int id)
    {
        var venta = await _context.Ventas.FindAsync(id);
        if (venta == null) return NotFound("Venta no encontrada");
        return venta;
    }


    [HttpPost]
    public async Task<ActionResult<Venta>> PostVenta(Venta venta)
    {
        _context.Ventas.Add(venta);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetVenta), new { id = venta.Id }, venta);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutVenta(int id, Venta venta)
    {
        var existe = await _context.Ventas.AnyAsync(v => v.Id == id);
        if (!existe) return NotFound();

        _context.Entry(venta).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVenta(int id)
    {
        var venta = await _context.Ventas.FindAsync(id);
        if (venta == null) return NotFound();

        _context.Ventas.Remove(venta);
        await _context.SaveChangesAsync();
        return Ok("Eliminado");
    }
}
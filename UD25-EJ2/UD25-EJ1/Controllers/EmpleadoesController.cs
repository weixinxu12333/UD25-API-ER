using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UD25_EJ1.Models;

namespace UD25_EJ1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoesController : ControllerBase
    {
        private readonly APIContext _context;

        public EmpleadoesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Empleadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }

        // GET: api/Empleadoes/5
        [HttpGet("{dni}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(string dni)
        {
            var empleado = await _context.Empleados.FindAsync(dni);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        // PUT: api/Empleadoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{dni}")]
        public async Task<IActionResult> PutEmpleado(string dni, Empleado empleado)
        {
            if (dni != empleado.Dni)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(dni))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Empleadoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmpleadoExists(empleado.Dni))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmpleado", new { id = empleado.Dni }, empleado);
        }

        // DELETE: api/Empleadoes/5
        [HttpDelete("{dni}")]
        public async Task<ActionResult<Empleado>> DeleteEmpleado(string dni)
        {
            var empleado = await _context.Empleados.FindAsync(dni);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return empleado;
        }

        private bool EmpleadoExists(string dni)
        {
            return _context.Empleados.Any(e => e.Dni == dni);
        }
    }
}

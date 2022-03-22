using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datos.Data;
using Datos.Negocio;
using Datos.Utils;

namespace ServicioPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly AraujoDastosContext _context;

        public CuentasController(AraujoDastosContext context)
        {
            _context = context;
        }

        // GET: api/Cuentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PCuenta>>> GetPCuentas()
        {
            return await _context.PCuentas.ToListAsync();
        }

        // GET: api/Cuentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PCuenta>> GetPCuenta(string id)
        {
            var pCuenta = await _context.PCuentas.FindAsync(id);

            if (pCuenta == null)
            {
                return NotFound();
            }

            return pCuenta;
        }

        // PUT: api/Cuentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPCuenta(string id, PCuenta pCuenta)
        {
            if (id != pCuenta.CuNumeroCuenta)
            {
                return BadRequest();
            }

            _context.Entry(pCuenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PCuentaExists(id))
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

        // POST: api/Cuentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Respuesta> PostPCuenta(PCuenta pCuenta)
        {
            Respuesta respuesta = new Respuesta();
            _context.PCuentas.Add(pCuenta);
            try
            {
                await _context.SaveChangesAsync();
                respuesta.IsSuccess = true;
            }
            catch (DbUpdateException e) 
            {
                respuesta.IsSuccess = false;
                if (PCuentaExists(pCuenta.CuNumeroCuenta))
                {
                    respuesta.Message = "La cuenta ya existe";
                }
                else
                {
                    respuesta.Message = "Ocurrio un error: " + e.StackTrace;
                }
            }

            respuesta.Resultado = CreatedAtAction("GetPCuenta", new { id = pCuenta.CuNumeroCuenta }, pCuenta);

            return respuesta;
        }

        // DELETE: api/Cuentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePCuenta(string id)
        {

            var pCuenta = await _context.PCuentas.FindAsync(id);
            if (pCuenta == null)
            {
                return NotFound();
            }

            _context.PCuentas.Remove(pCuenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PCuentaExists(string id)
        {
            return _context.PCuentas.Any(e => e.CuNumeroCuenta == id);
        }
    }
}

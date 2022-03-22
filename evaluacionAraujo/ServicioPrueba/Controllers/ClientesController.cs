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
    public class ClientesController : ControllerBase
    {
        private readonly AraujoDastosContext _context;

        public ClientesController(AraujoDastosContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PCliente>>> GetPClientes()
        {
            return await _context.PClientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<Respuesta> GetPCliente(int id)
        {
            Respuesta respuesta = new Respuesta();
            try {
                respuesta.Resultado = await _context.PClientes.FindAsync(id);
                respuesta.IsSuccess = true;
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }


            return respuesta;
        }



        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPCliente(int id, PCliente pCliente)
        {
            if (id != pCliente.ClIdCliente)
            {
                return BadRequest();
            }

            _context.Entry(pCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PClienteExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PCliente>> PostPCliente(PCliente pCliente)
        {
            _context.PClientes.Add(pCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPCliente", new { id = pCliente.ClIdCliente }, pCliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePCliente(int id)
        {
            var pCliente = await _context.PClientes.FindAsync(id);
            if (pCliente == null)
            {
                return NotFound();
            }

            _context.PClientes.Remove(pCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PClienteExists(int id)
        {
            return _context.PClientes.Any(e => e.ClIdCliente == id);
        }
    }
}

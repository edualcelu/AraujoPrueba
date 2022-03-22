using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datos.Data;
using Datos.Negocio;

namespace ServicioPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
    //    private readonly AraujoDastosContext _context;

    //    public PersonasController(AraujoDastosContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: api/Personas
    //    //[HttpGet]
    //    //public async Task<ActionResult<IEnumerable<PPersona>>> GetPPersonas()
    //    //{
    //    //    return await _context.PPersonas.ToListAsync();
    //    //}

    //    // GET: api/Personas/5
    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<PPersona>> GetPPersona(string id)
    //    {
    //        var pPersona = await _context.PPersonas.FindAsync(id);

    //        if (pPersona == null)
    //        {
    //            return NotFound();
    //        }

    //        return pPersona;
    //    }

    //    // PUT: api/Personas/5
    //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> PutPPersona(string id, PPersona pPersona)
    //    {
    //        if (id != pPersona.PeIdentificación)
    //        {
    //            return BadRequest();
    //        }

    //        _context.Entry(pPersona).State = EntityState.Modified;

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!PPersonaExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return NoContent();
    //    }

    //    // POST: api/Personas
    //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //    [HttpPost]
    //    public async Task<ActionResult<PPersona>> PostPPersona(PPersona pPersona)
    //    {
    //        _context.PPersonas.Add(pPersona);
    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateException)
    //        {
    //            if (PPersonaExists(pPersona.PeIdentificación))
    //            {
    //                return Conflict();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return CreatedAtAction("GetPPersona", new { id = pPersona.PeIdentificación }, pPersona);
    //    }

    //    // DELETE: api/Personas/5
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> DeletePPersona(string id)
    //    {
    //        var pPersona = await _context.PPersonas.FindAsync(id);
    //        if (pPersona == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.PPersonas.Remove(pPersona);
    //        await _context.SaveChangesAsync();

    //        return NoContent();
    //    }

    //    private bool PPersonaExists(string id)
    //    {
    //        return _context.PPersonas.Any(e => e.PeIdentificación == id);
    //    }
    //
    }
}

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
using Datos.ViewModels;

namespace ServicioPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly AraujoDastosContext _context;
        decimal VALOR_TOPE = 1000;
        string VALOR_CREDITO = "Credito";
        string VALOR_DEBITO = "Debito";


        public MovimientosController(AraujoDastosContext context)
        {
            _context = context;
        }

        // GET: api/Movimientos
        [HttpGet]
        public async Task<Respuesta> GetPMovimientos()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                
                respuesta.Resultado = await _context.PMovimientos.ToListAsync();
                respuesta.IsSuccess = true;
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;

        }

        // GET: api/Movimientos/5
        [HttpGet("{id}")]
        public async Task<Respuesta> GetPMovimiento(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Resultado = await _context.PMovimientos.FindAsync(id);
                respuesta.IsSuccess = true;
                if (respuesta.Resultado == null)
                {
                    respuesta.Message = "No existe datos";
                }
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
                respuesta.IsSuccess = false;
            }
            return respuesta;
        }

        // PUT: api/Movimientos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPMovimiento(int id, PMovimiento pMovimiento)
        {
            if (id != pMovimiento.MoIdMovimiento)
            {
                return BadRequest();
            }

            _context.Entry(pMovimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PMovimientoExists(id))
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

        // POST: api/Movimientos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Respuesta> PostPMovimiento(PMovimiento pMovimiento)
        {
            Respuesta respuesta = new Respuesta();

            pMovimiento.MoFecha = DateTime.Now;
            //Respuesta respuestaCuenta = new Respuesta();
            List<PMovimiento> lstUtlimoMovimiento = await _context.PMovimientos.Where(x => x.MoNumeroCuenta == pMovimiento.MoNumeroCuenta).OrderByDescending(x => x.MoFecha).ToListAsync();
            PMovimiento ultimoMovimiento = lstUtlimoMovimiento.FirstOrDefault();
            Respuesta resValidarTransaccion = await validarTransaccion(pMovimiento.MoNumeroCuenta, pMovimiento.MoMovimiento);
            if (!resValidarTransaccion.IsSuccess)
            {
                return resValidarTransaccion;
            }

            if (pMovimiento.MoMovimiento > 0)
            {
                pMovimiento.MoSaldoInicial = ultimoMovimiento.MoSaldoDisponible;
                pMovimiento.MoSaldoDisponible = ultimoMovimiento.MoSaldoDisponible + pMovimiento.MoMovimiento;
                pMovimiento.MoTipoMovimiento = VALOR_CREDITO;
                respuesta.IsSuccess = true;
            }
            else
            {
                if (ultimoMovimiento.MoSaldoDisponible < Math.Abs(pMovimiento.MoMovimiento))
                {
                    respuesta.Message = "Saldo no disponible";
                }
                else
                {
                    pMovimiento.MoSaldoInicial = ultimoMovimiento.MoSaldoDisponible;
                    pMovimiento.MoSaldoDisponible = ultimoMovimiento.MoSaldoDisponible + pMovimiento.MoMovimiento;
                    pMovimiento.MoTipoMovimiento = VALOR_DEBITO;
                    respuesta.IsSuccess = true;
                }

            }

            _context.PMovimientos.Add(pMovimiento);
            await _context.SaveChangesAsync();

            respuesta.Resultado = CreatedAtAction("GetPMovimiento", new { id = pMovimiento.MoIdMovimiento }, pMovimiento);
            return respuesta;
        }

        [HttpPost("{strNumeroCuenta},{decMontoTransaccion}")]
        public async Task<Respuesta> validarTransaccion(string strNumeroCuenta, decimal decMontoTransaccion)
        {
            Respuesta respuesta = new Respuesta();
            DateTime diaActual = DateTime.Now;

            string dia = diaActual.ToString("dd-MM-yyyy");
            DateTime InicioDeDia = DateTime.ParseExact(dia, "dd-MM-yyyy", null);
            DateTime FinalDeDia = DateTime.ParseExact(dia + " 23:59:59", "dd-MM-yyyy HH:mm:ss", null);
            List<PMovimiento> lstMovimientos = await _context.PMovimientos.Where(x => x.MoNumeroCuenta == strNumeroCuenta && x.MoFecha >= InicioDeDia && x.MoFecha <= FinalDeDia).ToListAsync();

            decimal total = 0;
            foreach (PMovimiento oPMovimiento in lstMovimientos)
            {
                if(string.Equals(oPMovimiento.MoTipoMovimiento, VALOR_DEBITO))
                    total = total + oPMovimiento.MoMovimiento;
            }

            decimal totalsupuesto = total + Math.Abs(decMontoTransaccion);

            respuesta.Resultado = total;
            if (totalsupuesto > VALOR_TOPE)
            {
                respuesta.Message = "Cupo diario excedido";
                respuesta.IsSuccess = false;
            }
            else
            {
                respuesta.IsSuccess = true;
            }

            return respuesta;

        }

        // DELETE: api/Movimientos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePMovimiento(int id)
        {
            var pMovimiento = await _context.PMovimientos.FindAsync(id);
            if (pMovimiento == null)
            {
                return NotFound();
            }

            _context.PMovimientos.Remove(pMovimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PMovimientoExists(int id)
        {
            return _context.PMovimientos.Any(e => e.MoIdMovimiento == id);
        }

        [HttpGet("{strIdentificacion}&{dtFechaInicio}&{dtFechaFin}")]
        public async Task<Respuesta> PostPMovimientosRango(string strIdentificacion, DateTime dtFechaInicio, DateTime dtFechaFin)
        {
            List<PMovimiento> lstPMovimiento = new List<PMovimiento>();
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Resultado = await _context.PMovimientos.Select(x => new ClienteMovimientos {
                    Fecha = x.MoFecha,
                    Nombre = x.MoNumeroCuentaNavigation.CuIdClienteNavigation.PeNombre,
                    NumeroCuenta = x.MoNumeroCuentaNavigation.CuNumeroCuenta,
                    Tipo = x.MoNumeroCuentaNavigation.CuTipo,
                    SaldoInicial = x.MoSaldoInicial,
                    Estado = x.MoNumeroCuentaNavigation.CuIdClienteNavigation.ClEstado,
                    Movimiento = x.MoMovimiento,
                    SaldoDisponible = x.MoSaldoDisponible,
                    Identificacion = x.MoNumeroCuentaNavigation.CuIdClienteNavigation.PeIdentificacion,

                }).Where(s => s.Identificacion == strIdentificacion && s.Fecha >= dtFechaInicio && s.Fecha <= dtFechaFin).ToListAsync();
                //respuesta.Resultado = await _context.PClientes.Include(a => a.) Where(x => x.PeIdentificacion == strIdentificacion).ToListAsync();
                //respuesta.Resultado = await _context.PMovimientos.Where(x => x.MoNumeroCuenta == strIdentificacion && x.MoFecha >= dtFechaInicio && x.MoFecha <= dtFechaFin).ToListAsync();
                respuesta.IsSuccess = true;
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;
        }
    }
}

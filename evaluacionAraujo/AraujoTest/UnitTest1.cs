using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioPrueba.Controllers;
using Datos.Data;
using Datos.Utils;

namespace AraujoTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly AraujoDastosContext _context;
        [TestMethod]
        public async void TestMethod1()
        {
             
            MovimientosController movimientos = new MovimientosController(_context);
            Respuesta respuesta = new Respuesta();
            respuesta = await movimientos.GetPMovimientos();
            Assert.IsTrue(respuesta.IsSuccess);

            
        }
    }
}

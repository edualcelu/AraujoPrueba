using System;
using System.Collections.Generic;

#nullable disable

namespace Datos.Negocio
{
    public partial class PMovimiento
    {
        public int MoIdMovimiento { get; set; }
        public string MoNumeroCuenta { get; set; }
        public DateTime MoFecha { get; set; }
        public string MoTipoMovimiento { get; set; }
        public decimal MoSaldoInicial { get; set; }
        public decimal MoMovimiento { get; set; }
        public decimal MoSaldoDisponible { get; set; }
        public virtual PCuenta MoNumeroCuentaNavigation { get; set; }
    }
}

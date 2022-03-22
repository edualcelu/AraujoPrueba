using System;
using System.Collections.Generic;

#nullable disable

namespace Datos.Negocio
{
    public partial class PCuenta
    {
        public PCuenta()
        {
            PMovimientos = new HashSet<PMovimiento>();
        }

        public string CuNumeroCuenta { get; set; }
        public int CuIdCliente { get; set; }
        public string CuTipo { get; set; }
        public bool CuEstado { get; set; }

        public virtual PCliente CuIdClienteNavigation { get; set; }
        public virtual ICollection<PMovimiento> PMovimientos { get; set; }
    }
}

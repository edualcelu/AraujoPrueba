using System;
using System.Collections.Generic;

namespace Datos.Negocio
{
    public partial class PCliente : PPersona
    {
        public PCliente()
        {
            PCuenta = new HashSet<PCuenta>();
        }

        public int ClIdCliente { get; set; }
        //public string ClIdentificación { get; set; }
        public string ClContrasenia { get; set; }
        public bool ClEstado { get; set; }

        //public virtual PPersona ClIdentificaciónNavigation { get; set; }
        public virtual ICollection<PCuenta> PCuenta { get; set; }
    }
}

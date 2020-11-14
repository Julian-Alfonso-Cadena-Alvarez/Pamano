using System;
using System.Collections.Generic;

namespace Pamano.Web
{
    public partial class Telefono
    {
        public Telefono()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTelefono { get; set; }
        public int IdTipoTelefono { get; set; }
        public string NumeroTelefonico { get; set; }

        public virtual TipoDeTelefono IdTipoTelefonoNavigation { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Pamano.Core.Domain
{
    public partial class TipoDeTelefono
    {
        public TipoDeTelefono()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTipoTelefono { get; set; }
        public string TipoTelefono { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}

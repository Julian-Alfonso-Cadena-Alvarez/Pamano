using System;
using System.Collections.Generic;

namespace Pamano.Core.Domain
{
    public partial class TipoDeTelefono
    {
        public TipoDeTelefono()
        {
            Telefono = new HashSet<Telefono>();
        }

        public int IdTipoTelefono { get; set; }
        public string TipoTelefono { get; set; }

        public virtual ICollection<Telefono> Telefono { get; set; }
    }
}

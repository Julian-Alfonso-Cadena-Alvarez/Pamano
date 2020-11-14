using System;
using System.Collections.Generic;

namespace Pamano.Web
{
    public partial class TipoDeProducto
    {
        public TipoDeProducto()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdTipoProducto { get; set; }
        public string NombreProducto { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}

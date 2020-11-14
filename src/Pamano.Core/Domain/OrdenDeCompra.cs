using System;
using System.Collections.Generic;

namespace Pamano.Web
{
    public partial class OrdenDeCompra
    {
        public OrdenDeCompra()
        {
            Inventario = new HashSet<Inventario>();
        }

        public int IdOrdenDeCompra { get; set; }
        public string NombreDelProveedor { get; set; }
        public int? ValorUnitarioDelProducto { get; set; }
        public int? ValorTotalDelProducto { get; set; }

        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}

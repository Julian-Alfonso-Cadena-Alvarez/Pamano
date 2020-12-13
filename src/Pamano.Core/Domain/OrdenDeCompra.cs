using System;
using System.Collections.Generic;

namespace Pamano.Core.Domain
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
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public int CantidadProducto { get; set; }
        public int? IdProducto { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}

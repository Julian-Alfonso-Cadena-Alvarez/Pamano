using System;
using System.Collections.Generic;

namespace Pamano.Core.Domain
{
    public partial class Producto
    {
        public Producto()
        {
            Inventario = new HashSet<Inventario>();
            OrdenDeCompra = new HashSet<OrdenDeCompra>();
            OrdenDeVenta = new HashSet<OrdenDeVenta>();
        }

        public int IdProducto { get; set; }
        public int? CantidadDeProducto { get; set; }
        public int? IdTipoDeProducto { get; set; }
        public int? PrecioDelProducto { get; set; }
        public string CaracteristicasDelProducto { get; set; }

        public virtual TipoDeProducto IdTipoDeProductoNavigation { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
        public virtual ICollection<OrdenDeCompra> OrdenDeCompra { get; set; }
        public virtual ICollection<OrdenDeVenta> OrdenDeVenta { get; set; }
    }
}

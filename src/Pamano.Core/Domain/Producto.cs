using System;
using System.Collections.Generic;

namespace Pamano.Core.Domain
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public int? CantidadDeProducto { get; set; }
        public int? IdTipoDeProducto { get; set; }
        public int? PrecioDelProducto { get; set; }
        public int IdInventario { get; set; }
        public string CaracteristicasDelProducto { get; set; }

        public virtual Inventario IdInventarioNavigation { get; set; }
        public virtual TipoDeProducto IdTipoDeProductoNavigation { get; set; }
    }
}

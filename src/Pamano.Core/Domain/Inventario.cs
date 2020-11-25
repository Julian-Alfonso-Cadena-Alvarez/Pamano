using System;
using System.Collections.Generic;

namespace Pamano.Core.Domain
{
    public partial class Inventario
    {
        public int IdInventario { get; set; }
        public DateTime? FechaDeIngreso { get; set; }
        public string IdUsuario { get; set; }
        public int IdOrdenDeVenta { get; set; }
        public int IdOrdenDeCompra { get; set; }
        public int IdPedido { get; set; }
        public int? IdProducto { get; set; }

        public virtual OrdenDeCompra IdOrdenDeCompraNavigation { get; set; }
        public virtual OrdenDeVenta IdOrdenDeVentaNavigation { get; set; }
        public virtual Pedidos IdPedidoNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Pamano.Web
{
    public partial class Pedidos
    {
        public Pedidos()
        {
            Inventario = new HashSet<Inventario>();
        }

        public int IdPedido { get; set; }
        public int? IdEstadoPedido { get; set; }
        public int? Cantidad { get; set; }
        public string IdUsuario { get; set; }

        public virtual EstadoDelPedido IdEstadoPedidoNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Pamano.Web
{
    public partial class EstadoDelPedido
    {
        public EstadoDelPedido()
        {
            Pedidos = new HashSet<Pedidos>();
        }

        public int IdEstado { get; set; }
        public string NombreEstadoDelPedido { get; set; }

        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}

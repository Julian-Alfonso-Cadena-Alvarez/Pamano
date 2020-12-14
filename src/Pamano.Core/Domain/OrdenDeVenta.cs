
using System;
using System.Collections.Generic;

namespace Pamano.Core.Domain
{
    public partial class OrdenDeVenta
    {
        public OrdenDeVenta()
        {
            Inventario = new HashSet<Inventario>();
        }

        public int IdOrdenDeVenta { get; set; }
        public int CantidadDelProducto { get; set; }
        public int ValorUnitario { get; set; }
        public int ValorTotal { get; set; }
        public DateTime? FechaDeVenta { get; set; }
        public string IdUsuario { get; set; }
        public int? IdProducto { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}

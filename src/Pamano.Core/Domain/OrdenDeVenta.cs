using System;
using System.Collections.Generic;

namespace Pamano.Web
{
    public partial class OrdenDeVenta
    {
        public OrdenDeVenta()
        {
            Inventario = new HashSet<Inventario>();
        }

        public int IdOrdenDeVenta { get; set; }
        public int? CantidadDelProducto { get; set; }
        public int? ValorUnitario { get; set; }
        public int? ValorTotal { get; set; }

        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}

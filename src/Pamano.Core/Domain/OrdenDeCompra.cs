using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int? ValorUnitarioDelProducto { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int? ValorTotalDelProducto { get; set; }
        public string Producto { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}

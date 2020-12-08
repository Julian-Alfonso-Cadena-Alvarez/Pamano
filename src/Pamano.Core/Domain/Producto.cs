using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pamano.Core.Domain
{
    public partial class Producto
    {
        public Producto()
        {
            Inventario = new HashSet<Inventario>();
        }

        public int IdProducto { get; set; }
        public int? CantidadDeProducto { get; set; }
        public int? IdTipoDeProducto { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public int? PrecioDelProducto { get; set; }
        public string CaracteristicasDelProducto { get; set; }

        public virtual TipoDeProducto IdTipoDeProductoNavigation { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}

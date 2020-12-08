using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Pamano.Core.Domain
{
    public partial class OrdenDeVenta
    {
        public OrdenDeVenta()
        {
            Inventario = new HashSet<Inventario>();
        }

        public int IdOrdenDeVenta { get; set; }
        public int? CantidadDelProducto { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int? ValorUnitario { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int? ValorTotal { get; set; }
        public DateTime? FechaDeVenta { get; set; }
        public string IdUsuario { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}

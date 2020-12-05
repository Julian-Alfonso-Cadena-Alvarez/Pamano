using System;
using System.Collections.Generic;

namespace Pamano.Core.Domain
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Inventario = new HashSet<Inventario>();
            OrdenDeVenta = new HashSet<OrdenDeVenta>();
            Pedidos = new HashSet<Pedidos>();
        }

        public string IdUsuario { get; set; }
        public int IdRol { get; set; }
        public int? IdTipoTelefono { get; set; }
        public string Telefono { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual TipoDeTelefono IdTipoTelefonoNavigation { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
        public virtual ICollection<OrdenDeVenta> OrdenDeVenta { get; set; }
        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}

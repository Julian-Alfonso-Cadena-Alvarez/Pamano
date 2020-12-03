using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pamano.Core.Domain;

namespace Pamano.Infrastructure.Data
{
    public partial class PamanoDbContext : DbContext
    {
        public PamanoDbContext()
        {
        }

        public PamanoDbContext(DbContextOptions<PamanoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EstadoDelPedido> EstadoDelPedido { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<OrdenDeCompra> OrdenDeCompra { get; set; }
        public virtual DbSet<OrdenDeVenta> OrdenDeVenta { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Telefono> Telefono { get; set; }
        public virtual DbSet<TipoDeProducto> TipoDeProducto { get; set; }
        public virtual DbSet<TipoDeTelefono> TipoDeTelefono { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySQL("database=Pamano;server=localhost;port=3306;user id=root;password=");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoDelPedido>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PRIMARY");

                entity.ToTable("estado_del_pedido");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("id_estado")
                    .HasColumnType("int(3)");

                entity.Property(e => e.NombreEstadoDelPedido)
                    .HasColumnName("Nombre_estado_del_pedido")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario)
                    .HasName("PRIMARY");

                entity.ToTable("inventario");

                entity.HasIndex(e => e.IdOrdenDeCompra)
                    .HasName("ID_orden_de_compra");

                entity.HasIndex(e => e.IdOrdenDeVenta)
                    .HasName("ID_orden_de_venta");

                entity.HasIndex(e => e.IdPedido)
                    .HasName("ID_pedido");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("id_producto");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("ID_usuario");

                entity.Property(e => e.IdInventario)
                    .HasColumnName("ID_inventario")
                    .HasColumnType("int(3)");

                entity.Property(e => e.FechaDeIngreso)
                    .HasColumnName("Fecha_de_ingreso")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdOrdenDeCompra)
                    .HasColumnName("ID_orden_de_compra")
                    .HasColumnType("int(3)");

                entity.Property(e => e.IdOrdenDeVenta)
                    .HasColumnName("ID_orden_de_venta")
                    .HasColumnType("int(3)");

                entity.Property(e => e.IdPedido)
                    .HasColumnName("ID_pedido")
                    .HasColumnType("int(3)");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasColumnName("ID_usuario")
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdOrdenDeCompraNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.IdOrdenDeCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("inventario_ibfk_2");

                entity.HasOne(d => d.IdOrdenDeVentaNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.IdOrdenDeVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("inventario_ibfk_4");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("inventario_ibfk_5");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("inventario_ibfk_7");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("inventario_ibfk_6");
            });

            modelBuilder.Entity<OrdenDeCompra>(entity =>
            {
                entity.HasKey(e => e.IdOrdenDeCompra)
                    .HasName("PRIMARY");

                entity.ToTable("orden_de_compra");

                entity.Property(e => e.IdOrdenDeCompra)
                    .HasColumnName("ID_orden_de_compra")
                    .HasColumnType("int(3)");

                entity.Property(e => e.NombreDelProveedor)
                    .HasColumnName("Nombre_del_proveedor")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Producto)
                    .IsRequired()
                    .HasColumnName("producto")
                    .HasMaxLength(30);

                entity.Property(e => e.ValorTotalDelProducto)
                    .HasColumnName("Valor_total_del_producto")
                    .HasColumnType("int(8)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ValorUnitarioDelProducto)
                    .HasColumnName("Valor_unitario_del_producto")
                    .HasColumnType("int(5)")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<OrdenDeVenta>(entity =>
            {
                entity.HasKey(e => e.IdOrdenDeVenta)
                    .HasName("PRIMARY");

                entity.ToTable("orden_de_venta");

                entity.Property(e => e.IdOrdenDeVenta)
                    .HasColumnName("ID_orden_de_venta")
                    .HasColumnType("int(3)");

                entity.Property(e => e.CantidadDelProducto)
                    .HasColumnName("Cantidad_del_producto")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ValorTotal)
                    .HasColumnName("Valor_total")
                    .HasColumnType("int(8)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ValorUnitario)
                    .HasColumnName("Valor_unitario")
                    .HasColumnType("int(5)")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PRIMARY");

                entity.ToTable("pedidos");

                entity.HasIndex(e => e.IdEstadoPedido)
                    .HasName("id_estado_pedido");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("ID_usuario");

                entity.Property(e => e.IdPedido)
                    .HasColumnName("ID_pedido")
                    .HasColumnType("int(3)");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("int(100)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdEstadoPedido)
                    .HasColumnName("id_estado_pedido")
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasColumnName("ID_usuario")
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdEstadoPedidoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdEstadoPedido)
                    .HasConstraintName("id_estado_pedido");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pedidos_ibfk_1");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("producto");

                entity.HasIndex(e => e.IdTipoDeProducto)
                    .HasName("id_tipo_de_producto");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("ID_producto")
                    .HasColumnType("int(3)");

                entity.Property(e => e.CantidadDeProducto)
                    .HasColumnName("Cantidad_de_producto")
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CaracteristicasDelProducto)
                    .HasColumnName("Caracteristicas_del_producto")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdTipoDeProducto)
                    .HasColumnName("id_tipo_de_producto")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PrecioDelProducto)
                    .HasColumnName("Precio_del_producto")
                    .HasColumnType("int(8)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdTipoDeProductoNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdTipoDeProducto)
                    .HasConstraintName("producto_ibfk_3");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PRIMARY");

                entity.ToTable("rol");

                entity.Property(e => e.IdRol)
                    .HasColumnName("ID_rol")
                    .HasColumnType("int(1)");

                entity.Property(e => e.TipoDeRol)
                    .HasColumnName("Tipo_de_rol")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Telefono>(entity =>
            {
                entity.HasKey(e => e.IdTelefono)
                    .HasName("PRIMARY");

                entity.ToTable("telefono");

                entity.HasIndex(e => e.IdTipoTelefono)
                    .HasName("id_tipo_telefono");

                entity.Property(e => e.IdTelefono)
                    .HasColumnName("id_telefono")
                    .HasColumnType("int(1)");

                entity.Property(e => e.IdTipoTelefono)
                    .HasColumnName("id_tipo_telefono")
                    .HasColumnType("int(1)");

                entity.Property(e => e.NumeroTelefonico)
                    .IsRequired()
                    .HasColumnName("Numero_telefonico")
                    .HasMaxLength(11);

                entity.HasOne(d => d.IdTipoTelefonoNavigation)
                    .WithMany(p => p.Telefono)
                    .HasForeignKey(d => d.IdTipoTelefono)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("telefono_ibfk_1");
            });

            modelBuilder.Entity<TipoDeProducto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProducto)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_de_producto");

                entity.Property(e => e.IdTipoProducto)
                    .HasColumnName("id_tipo_producto")
                    .HasColumnType("int(2)");

                entity.Property(e => e.NombreProducto)
                    .HasColumnName("Nombre_producto")
                    .HasMaxLength(25)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TipoDeTelefono>(entity =>
            {
                entity.HasKey(e => e.IdTipoTelefono)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_de_telefono");

                entity.Property(e => e.IdTipoTelefono)
                    .HasColumnName("id_tipo_telefono")
                    .HasColumnType("int(1)");

                entity.Property(e => e.TipoTelefono)
                    .HasColumnName("tipo_telefono")
                    .HasMaxLength(7)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.IdRol)
                    .HasName("ID_rol");

                entity.HasIndex(e => e.IdTelefono)
                    .HasName("id_telefono");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_usuario")
                    .HasMaxLength(10);

                entity.Property(e => e.IdRol)
                    .HasColumnName("ID_rol")
                    .HasColumnType("int(3)");

                entity.Property(e => e.IdTelefono)
                    .HasColumnName("id_telefono")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PrimerApellido)
                    .HasColumnName("Primer_apellido")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PrimerNombre)
                    .HasColumnName("Primer_nombre")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("Segundo_apellido")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SegundoNombre)
                    .IsRequired()
                    .HasColumnName("Segundo_nombre")
                    .HasMaxLength(15);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuarios_ibfk_1");

                entity.HasOne(d => d.IdTelefonoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTelefono)
                    .HasConstraintName("id_telefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

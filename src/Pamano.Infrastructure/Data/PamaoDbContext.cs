using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pamano.Infrastructure;
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

        public virtual DbSet<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetroles> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusers> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetusertokens> Aspnetusertokens { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<EstadoDelPedido> EstadoDelPedido { get; set; }
        public virtual DbSet<IdentityuserString> IdentityuserString { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<OrdenDeCompra> OrdenDeCompra { get; set; }
        public virtual DbSet<OrdenDeVenta> OrdenDeVenta { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<TipoDeProducto> TipoDeProducto { get; set; }
        public virtual DbSet<TipoDeTelefono> TipoDeTelefono { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySQL("database=pamano;server=localhost;port=3306;user id=root;password=;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aspnetroleclaims>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ClaimValue).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(127);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetroles>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(127);

                entity.Property(e => e.ConcurrencyStamp)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NormalizedName)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Aspnetuserclaims>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ClaimValue).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(127);

                entity.Property(e => e.ProviderKey).HasMaxLength(127);

                entity.Property(e => e.ProviderDisplayName).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserroles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.UserId).HasMaxLength(127);

                entity.Property(e => e.RoleId).HasMaxLength(127);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusers>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NormalizedEmail)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NormalizedUserName)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PasswordHash).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PhoneNumber).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SecurityStamp).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserName)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Aspnetusertokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.UserId).HasMaxLength(127);

                entity.Property(e => e.LoginProvider).HasMaxLength(127);

                entity.Property(e => e.Name).HasMaxLength(127);

                entity.Property(e => e.Value).HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<EstadoDelPedido>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PRIMARY");

                entity.ToTable("estado_del_pedido");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("id_estado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreEstadoDelPedido)
                    .HasColumnName("Nombre_estado_del_pedido")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<IdentityuserString>(entity =>
            {
                entity.ToTable("identityuser<string>");

                entity.Property(e => e.Id).HasMaxLength(127);

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NormalizedEmail).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NormalizedUserName).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PasswordHash).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PhoneNumber).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SecurityStamp).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserName).HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario)
                    .HasName("PRIMARY");

                entity.ToTable("inventario");

                entity.HasIndex(e => e.IdOrdenDeCompra)
                    .HasName("id_orden_de_compra");

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
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaDeIngreso)
                    .HasColumnName("Fecha_de_ingreso")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdOrdenDeCompra)
                    .HasColumnName("id_orden_de_compra")
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdOrdenDeVenta)
                    .HasColumnName("ID_orden_de_venta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPedido)
                    .HasColumnName("ID_pedido")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasColumnName("ID_usuario")
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdOrdenDeCompraNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.IdOrdenDeCompra)
                    .HasConstraintName("inventario_ibfk_8");

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

                entity.HasIndex(e => e.IdProducto)
                    .HasName("id_productofk");

                entity.Property(e => e.IdOrdenDeCompra)
                    .HasColumnName("ID_orden_de_compra")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CantidadProducto)
                    .HasColumnName("cantidadProducto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(25)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NombreDelProveedor)
                    .HasColumnName("Nombre_del_proveedor")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(11)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ValorTotalDelProducto)
                    .HasColumnName("Valor_total_del_producto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ValorUnitarioDelProducto)
                    .HasColumnName("Valor_unitario_del_producto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.OrdenDeCompra)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("id_productofk");
            });

            modelBuilder.Entity<OrdenDeVenta>(entity =>
            {
                entity.HasKey(e => e.IdOrdenDeVenta)
                    .HasName("PRIMARY");

                entity.ToTable("orden_de_venta");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("id_producto");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("id_usuario");

                entity.Property(e => e.IdOrdenDeVenta)
                    .HasColumnName("ID_orden_de_venta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CantidadDelProducto)
                    .HasColumnName("Cantidad_del_producto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FechaDeVenta)
                    .HasColumnName("fecha_de_venta")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ValorTotal)
                    .HasColumnName("Valor_total")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ValorUnitario)
                    .HasColumnName("Valor_unitario")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.OrdenDeVenta)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("id_producto");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.OrdenDeVenta)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("orden_de_venta_ibfk_1");
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
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdEstadoPedido)
                    .HasColumnName("id_estado_pedido")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_usuario")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdEstadoPedidoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdEstadoPedido)
                    .HasConstraintName("id_estado_pedido");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdUsuario)
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
                    .HasColumnType("int(11)");

                entity.Property(e => e.CantidadDeProducto)
                    .HasColumnName("Cantidad_de_producto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CaracteristicasDelProducto)
                    .HasColumnName("Caracteristicas_del_producto")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdTipoDeProducto)
                    .HasColumnName("id_tipo_de_producto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PrecioDelProducto)
                    .HasColumnName("Precio_del_producto")
                    .HasColumnType("int(11)")
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
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoDeRol)
                    .HasColumnName("Tipo_de_rol")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TipoDeProducto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProducto)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_de_producto");

                entity.Property(e => e.IdTipoProducto)
                    .HasColumnName("id_tipo_producto")
                    .HasColumnType("int(11)");

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
                    .HasColumnType("int(11)");

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

                entity.HasIndex(e => e.IdTipoTelefono)
                    .HasName("id_telefono");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_usuario")
                    .HasMaxLength(10);

                entity.Property(e => e.IdRol)
                    .HasColumnName("ID_rol")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoTelefono)
                    .HasColumnName("id_tipo_telefono")
                    .HasColumnType("int(11)")
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

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuarios_ibfk_1");

                entity.HasOne(d => d.IdTipoTelefonoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoTelefono)
                    .HasConstraintName("usuarios_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

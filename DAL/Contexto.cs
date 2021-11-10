using Microsoft.EntityFrameworkCore;
using Perla_AP2_API_20190008.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perla_AP2_API_20190008.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source=DATA\DBParcial2.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Proveedores>().HasData(
                new Proveedores { ProveedorId = 1, Nombre = "Bodega de Jesus" }
                );
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Proveedores>().HasData(
                new Proveedores { ProveedorId = 2, Nombre = "Bodega Rodriguez" }
                );
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Proveedores>().HasData(
                new Proveedores { ProveedorId = 3, Nombre = "Supermercado Suarez" }
                );
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Proveedores>().HasData(
                new Proveedores { ProveedorId = 4, Nombre = "Supermercado Canario" }
                );
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Articulos>().HasData(
                new Articulos{ ArticuloId = 1, Descripcion = "Caja de avena" }
                );
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Articulos>().HasData(
                new Articulos { ArticuloId= 2, Descripcion = "Faldos de refrescos" }
                );
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Articulos>().HasData(
                new Articulos { ArticuloId = 3, Descripcion = "Cajas de sopa" }
                );
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Articulos>().HasData(
                new Articulos { ArticuloId= 4, Descripcion = "Embutidos" }
                );
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Articulos>().HasData(
                new Articulos { ArticuloId = 5, Descripcion = "Cajas de jabones" }
                );
        }
    }
}

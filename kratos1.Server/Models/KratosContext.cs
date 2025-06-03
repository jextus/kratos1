﻿using Microsoft.EntityFrameworkCore;
using krat1.Server.Models.Kratos;
using System.Collections.Generic;
using System.Reflection.Emit;
using Krat1.Server.Models.Kratos;

namespace Krat1.Server.Models
{
    public class KratosContext : DbContext
    {
        public KratosContext(DbContextOptions<KratosContext> options) : base(options)
        {
        }
        public DbSet<ActividadEconomicas> ActividadEconomicas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Impuestos> Impuestos { get; set; }
        public DbSet<Inventarios> Inventarios { get; set; }
        public DbSet<Modulos> Modulos { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<PuntoVentas> PuntoVentas { get; set; }
        public DbSet<RegimenesTributarios> RegimenesTributarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<TiposSociedades> TiposSociedades { get; set; }
        public DbSet<TratamientosEmpresas> TratamientosEmpresas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Empresas -> TiposSociedades
            modelBuilder.Entity<Empresas>()
                .HasOne(e => e.empresasociedadFk)
                .WithMany()
                .HasForeignKey(e => e.tiposociedadId)
                .OnDelete(DeleteBehavior.Restrict);

            // Empresas -> ActividadEconomicas
            modelBuilder.Entity<Empresas>()
                .HasOne(e => e.empresaactividadFk)
                .WithMany()
                .HasForeignKey(e => e.actividadId)
                .OnDelete(DeleteBehavior.Restrict);

            // Empresas -> RegimenesTributarios
            modelBuilder.Entity<Empresas>()
                .HasOne(e => e.empresaregimenFk)
                .WithMany()
                .HasForeignKey(e => e.regimenId)
                .OnDelete(DeleteBehavior.Restrict);

            // Roles -> Empresas
            modelBuilder.Entity<Roles>()
                .HasOne(r => r.rolempresaFk)
                .WithMany()
                .HasForeignKey(r => r.empresaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Productos -> TratamientosEmpresas
            modelBuilder.Entity<Productos>()
                .HasOne(p => p.impuestoFk)
                .WithMany()
                .HasForeignKey(p => p.impuestoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Productos -> Categorias
            modelBuilder.Entity<Productos>()
                .HasOne(p => p.categoriaFk)
                .WithMany()
                .HasForeignKey(p => p.categoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Inventarios -> Productos
            modelBuilder.Entity<Inventarios>()
                .HasOne(i => i.productoFk)
                .WithMany()
                .HasForeignKey(i => i.productoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Inventarios -> PuntoVentas
            modelBuilder.Entity<Inventarios>()
                .HasOne(i => i.puntoventaFk)
                .WithMany()
                .HasForeignKey(i => i.puntoventaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Impuestos -> TiposSociedades
            modelBuilder.Entity<Impuestos>()
                .HasOne(i => i.impuestosociedadesFk)
                .WithMany()
                .HasForeignKey(i => i.sociedadesId)
                .OnDelete(DeleteBehavior.Restrict);

            // Impuestos -> ActividadEconomicas
            modelBuilder.Entity<Impuestos>()
                .HasOne(i => i.impuestoactividadFk)
                .WithMany()
                .HasForeignKey(i => i.actividadId)
                .OnDelete(DeleteBehavior.Restrict);

            // Impuestos -> RegimenesTributarios
            modelBuilder.Entity<Impuestos>()
                .HasOne(i => i.impuestoregimenFk)
                .WithMany()
                .HasForeignKey(i => i.regimenId)
                .OnDelete(DeleteBehavior.Restrict);

            // Permisos -> Roles
            modelBuilder.Entity<Permisos>()
                .HasOne(p => p.permisosrolesId)
                .WithMany()
                .HasForeignKey(p => p.rolesId)
                .OnDelete(DeleteBehavior.Restrict);

            // Permisos -> Modulos
            modelBuilder.Entity<Permisos>()
                .HasOne(p => p.permisosmodulosId)
                .WithMany()
                .HasForeignKey(p => p.modulosId)
                .OnDelete(DeleteBehavior.Restrict);

            // PuntoVentas -> Usuarios
            modelBuilder.Entity<PuntoVentas>()
                .HasOne(pv => pv.usuarioFk)
                .WithMany()
                .HasForeignKey(pv => pv.responsableId)
                .OnDelete(DeleteBehavior.Restrict);

            // Usuarios -> Roles
            modelBuilder.Entity<Usuarios>()
                .HasOne(u => u.usuariosrolesFk)
                .WithMany()
                .HasForeignKey(u => u.rolesId)
                .OnDelete(DeleteBehavior.Restrict);

            // TratamientosEmpresas -> Empresas
            modelBuilder.Entity<TratamientosEmpresas>()
                .HasOne(te => te.empresaFk)
                .WithMany()
                .HasForeignKey(te => te.empresaId)
                .OnDelete(DeleteBehavior.Restrict);

            // TratamientosEmpresas -> Impuestos
            modelBuilder.Entity<TratamientosEmpresas>()
                .HasOne(te => te.impuestosFk)
                .WithMany()
                .HasForeignKey(te => te.tipoimpuestoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Categorias -> Categorias (self reference)
            modelBuilder.Entity<Categorias>()
                .HasOne(c => c.categoriapadreFk)
                .WithMany()
                .HasForeignKey(c => c.categoriapadreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

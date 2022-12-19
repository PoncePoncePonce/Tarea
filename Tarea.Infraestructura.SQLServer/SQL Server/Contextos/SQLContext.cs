using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Tarea.Business.Entidades;

namespace Tarea.Infraestructura.SQL.SQL_Server.Contextos
{
    public class SQLContext: DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Doctores> Doctores { get; set; }
        public DbSet<Citas> Citas { get; set; }
        public SQLContext(DbContextOptions opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");
            builder.Entity<Clientes>().ToTable("Clientes", "cat").HasKey(e => e.Id).HasName("codigoCliente");

            builder.Entity<Clientes>().Property(p => p.Nombre).HasMaxLength(50).IsRequired().HasColumnName("NombreCliente");

            builder.Entity<Clientes>().Property(p => p.Apellido).HasMaxLength(50).IsRequired().HasColumnName("ApellidoCliente");

            builder.Entity<Clientes>().Property(p => p.Direccion).HasMaxLength(200).IsRequired().HasColumnName("DireccionCliente");

            //docs
            builder.Entity<Doctores>().ToTable("Doctores", "cat").HasKey(e => e.Id).HasName("codigoDoctor");

            builder.Entity<Doctores>().Property(p => p.Nombre).HasMaxLength(50).IsRequired().HasColumnName("NombreDoctor");

            builder.Entity<Doctores>().Property(p => p.Apellido).HasMaxLength(50).IsRequired().HasColumnName("ApellidoDoctor");

            builder.Entity<Doctores>().Property(p => p.Cedula).HasMaxLength(16).IsRequired().HasColumnName("CedulaDoctor");

            //citas
            builder.Entity<Citas>().ToTable("Citas", "cat").HasKey(sc => sc.Id).HasName("codigoCita");
            builder.Entity<Citas>().HasOne<Clientes>(sc => sc.Clientes).WithMany(s => s.Citas).HasForeignKey(e => e.clienteId);
            builder.Entity<Citas>().HasOne<Doctores>(sc => sc.Doctores).WithMany(s => s.Citas).HasForeignKey(e => e.doctorId);
            builder.Entity<Citas>().Property(p => p.Fecha).IsRequired().HasColumnName("fechaDeConsulta");
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server = LAP-MARTINP\\SQLEXPRESS;  Database = Consultorio; Trusted_Connection = true");
        }
    }
}

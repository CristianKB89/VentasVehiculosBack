using Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Back.Infraestructure.Persistences.Contexts;

public partial class VentasVehiculosContext : DbContext
{
    public VentasVehiculosContext()
    {
    }

    public VentasVehiculosContext(DbContextOptions<VentasVehiculosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Concesionario> Concesionarios { get; set; }

    public virtual DbSet<Transacciones> Transacciones { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

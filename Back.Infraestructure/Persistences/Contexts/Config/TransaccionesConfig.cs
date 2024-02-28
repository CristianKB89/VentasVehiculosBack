using Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Infraestructure.Persistences.Contexts.Config
{
    public class TransaccionesConfig : IEntityTypeConfiguration<Transacciones>
    {
        public void Configure(EntityTypeBuilder<Transacciones> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("TransaccionID");
            builder.Property(e => e.ClienteID).HasColumnName("ClienteID");
            builder.Property(e => e.ConcesionarioID).HasColumnName("ConcesionarioID");
            builder.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            builder.Property(e => e.FechaRegistro).HasColumnType("datetime");
            builder.Property(e => e.FechaVenta).HasColumnType("datetime");
            builder.Property(e => e.PrecioVenta).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.VehiculoID).HasColumnName("VehiculoID");

            builder.HasOne(d => d.Cliente).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.ClienteID)
                .HasConstraintName("FK__Transacci__Clien__3D5E1FD2");

            builder.HasOne(d => d.Concesionario).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.ConcesionarioID)
                .HasConstraintName("FK__Transacci__Conce__3E52440B");

            builder.HasOne(d => d.Vehiculo).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.VehiculoID)
                .HasConstraintName("FK__Transacci__Vehic__3C69FB99");
        }
    }
}

using Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Infraestructure.Persistences.Contexts.Config
{
    public class VehiculoConfig : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("VehiculoID");
            builder.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            builder.Property(e => e.FechaRegistro).HasColumnType("datetime");
            builder.Property(e => e.Marca).HasMaxLength(50);
            builder.Property(e => e.Modelo).HasMaxLength(50);
            builder.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        }
    }
}

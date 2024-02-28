using Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Infraestructure.Persistences.Contexts.Config
{
    public class ConcesionarioConfig : IEntityTypeConfiguration<Concesionario>
    {
        public void Configure(EntityTypeBuilder<Concesionario> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ConcesionarioID");
            builder.Property(e => e.Ciudad).HasMaxLength(50);
            builder.Property(e => e.Direccion).HasMaxLength(255);
            builder.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            builder.Property(e => e.FechaRegistro).HasColumnType("datetime");
            builder.Property(e => e.Nombre).HasMaxLength(100);
        }
    }
}

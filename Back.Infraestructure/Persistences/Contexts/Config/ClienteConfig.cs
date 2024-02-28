using Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Infraestructure.Persistences.Contexts.Config
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ClienteID");
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            builder.Property(e => e.FechaRegistro).HasColumnType("datetime");
            builder.Property(e => e.Nombre).HasMaxLength(100);
            builder.Property(e => e.Telefono).HasMaxLength(20);
        }
    }
}

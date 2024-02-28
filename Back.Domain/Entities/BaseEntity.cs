namespace Back.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public bool? Estado { get; set; }
    }
}

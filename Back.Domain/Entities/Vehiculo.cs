namespace Back.Domain.Entities;

public partial class Vehiculo : BaseEntity
{
    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int? Anio { get; set; }

    public decimal? Precio { get; set; }

    public virtual ICollection<Transacciones> Transacciones { get; set; } = new List<Transacciones>();
}

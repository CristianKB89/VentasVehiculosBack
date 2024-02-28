namespace Back.Domain.Entities;

public partial class Concesionario : BaseEntity
{
    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public virtual ICollection<Transacciones> Transacciones { get; set; } = new List<Transacciones>();
}

namespace Back.Domain.Entities;

public partial class Cliente : BaseEntity
{
    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Transacciones> Transacciones { get; set; } = new List<Transacciones>();
}

namespace Back.Domain.Entities;

public partial class Transacciones : BaseEntity
{
    public int? VehiculoID { get; set; }

    public int? ClienteID { get; set; }

    public int? ConcesionarioID { get; set; }

    public DateTime? FechaVenta { get; set; }

    public decimal? PrecioVenta { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Concesionario? Concesionario { get; set; }

    public virtual Vehiculo? Vehiculo { get; set; }
}

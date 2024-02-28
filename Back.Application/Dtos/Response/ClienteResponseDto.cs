namespace Back.Application.Dtos.Response
{
    public class ClienteResponseDto
    {
        public int ClienteID { get; set; }

        public string? Nombre { get; set; }

        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public string? Estado { get; set; }
    }
}

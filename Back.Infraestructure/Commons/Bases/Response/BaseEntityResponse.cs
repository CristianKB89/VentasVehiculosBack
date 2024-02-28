namespace Back.Infraestructure.Commons.Bases.Response
{
    public class BaseEntityResponse<T>
    {
        public int? TotalRegistros { get; set; }
        public List<T>? Items { get; set; }
    }
}

namespace Back.Infraestructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepository Cliente { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}

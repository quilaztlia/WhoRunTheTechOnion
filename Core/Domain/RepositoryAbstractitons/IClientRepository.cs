namespace Domain;
public interface IClientRepository{
    Task<IEnumerable<Client>> GetAllAsync(CancellationToken cancellationToken=default);
    Task<Client> GetByIdAsync(CancellationToken cancellationToken= default);
    Task<Guid> CreateAsync(Client client);
    Task<bool> DeleteAsync(Client client);
}
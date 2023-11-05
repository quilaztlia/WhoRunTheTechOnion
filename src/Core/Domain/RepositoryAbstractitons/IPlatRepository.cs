using Domain.Entities;

namespace Domain.Repository.Abstraction;

public interface IPlatRepository
{
    Task<IEnumerable<Plat>> GetAllByIdRestaurantAsync(Guid idRestaurant, CancellationToken cancellationToken=default);
    Task<Guid> CreateInRestaurantAsync(Guid idRestaurant, Plat plat, CancellationToken cancellationToken=default);
    Task<Guid> DeleteInRestaurantAsync(Guid idRestaurant, Plat plat, CancellationToken cancellationToken=default);
}

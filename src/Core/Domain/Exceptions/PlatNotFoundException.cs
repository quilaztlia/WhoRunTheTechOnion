namespace Domain.Exceptions;

public sealed class PlatNotFoundException
: NotFoundException
{
    public PlatNotFoundException(Guid idRestaurant, Guid idPlat)
        : base($"Le restaurant id {idRestaurant} ne vends pas le plat id {idPlat}")
    {        
    }
}

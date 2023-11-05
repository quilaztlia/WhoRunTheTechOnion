namespace Domain.Entities;

public class Plat
{
    public Guid Id { get; init; }
    public Guid IdRestaurant { get; set; }
    public string Nom { get; set; } = string.Empty;
}

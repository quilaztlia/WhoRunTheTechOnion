namespace Domain.Entities;

public class Restaurant
{
    public Guid Id { get; init; }
    public string Nom { get; set; } = string.Empty;
}

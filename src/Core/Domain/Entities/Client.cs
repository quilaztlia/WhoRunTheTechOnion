namespace Domain.Entities;

public class Client
{
    public Guid Id { get; init; }
    public string Nom { get; set; } = string.Empty;
    public string Prenom { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
}

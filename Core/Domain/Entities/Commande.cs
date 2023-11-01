namespace Domain;

public class Commande
{
    public Guid Id { get; init; } //Init or set ?
    public Guid IdClient { get; set; }
    public Guid IdRestaurant { get; set; }
    public ICollection<Plat> Plats{get; set;}
}

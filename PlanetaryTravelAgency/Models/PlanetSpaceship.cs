namespace PlanetaryTravelAgency.Models
{
  public class PlanetSpaceship
  {
    public int PlanetSpaceshipId { get; set; }
    public int SpaceshipId { get; set; }
    public int PlanetId { get; set; }
    public virtual Spaceship Spaceship { get; set; }
    public virtual Planet Planet { get; set; }
  }
}
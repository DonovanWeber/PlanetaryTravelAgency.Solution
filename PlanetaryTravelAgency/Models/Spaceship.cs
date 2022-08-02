using System.Collections.Generic;
using System.Linq;
using System;
using System.Web;

namespace PlanetaryTravelAgency.Models
{
  public class Spaceship
  {
    public Spaceship()
    {
      this.JoinEntities = new HashSet<PlanetSpaceship>();
    }
    
    public int SpaceshipId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Fuel { get; set; }
    public int Capacity { get; set; }
    public virtual ICollection<PlanetSpaceship> JoinEntities { get; set; }
  }
}
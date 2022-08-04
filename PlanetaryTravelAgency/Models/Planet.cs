using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PlanetaryTravelAgency.Models
{
  public class Planet
  {
    public Planet()
    {
      this.JoinEntities = new HashSet<PlanetSpaceship>();
    }

    public int PlanetId { get; set; }
    public string Name { get; set; }
    public int Distance { get ; set; }
    public string Weather { get; set; }
    public int Temperature { get; set; }
    public int Radiation { get; set; }
    public virtual ICollection<PlanetSpaceship> JoinEntities { get; set; }

    }
  }

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
    public string HdUrl { get; set; }
    public string Title { get; set;}
    public virtual ICollection<PlanetSpaceship> JoinEntities { get; set; }

    public static List<Planet> GetPlanets(string apiKey)
    {
      var apiCallTask = ApiHelper.ApiCall(apiKey);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Planet> planetList = JsonConvert.DeserializeObject<List<Planet>>(jsonResponse["results"].ToString());

    return planetList;
    }
  }
}
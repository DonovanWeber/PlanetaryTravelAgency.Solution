using System;
using System.Threading.Tasks;
using RestSharp;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace PlanetaryTravelAgency
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = new WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        .Build();

      host.Run();
    }
  }
}
  // class ApiCall
  // {
  //   static void Main2()
  //   {
  //     var apiCallTask = Models.ApiHelper.ApiCall("I4TdB92OHOGDBmWf6FesyTLJM8MrW7paWnKLHpMi");
  //     var result = apiCallTask.Result;
  // JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
  // Console.WriteLine(jsonResponse["results"]);
  //   }
  // }

// using System.Threading.Tasks;
// using RestSharp;

// namespace PlanetaryTravelAgency.Models
// {
//    class ApiHelper
//   {
//     public static async Task<string> GetAll()
//     {
//       RestClient client = new RestClient("[GET https://api.nasa.gov/planetary/apod?api_key=&count=1");
//       RestRequest request = new RestRequest($"hdurl", "title", Method.GET);
//       var response = await client.ExecuteTaskAsync(request);
//       return response.Content;
//     }
//   }
// }
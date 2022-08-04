// using System.Collections.Generic;
// using System;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;

// namespace PlanetaryTravelAgency.Models
// {
//   public class Apod
//   {
//     public string HdUrl { get; set; }
//     public string Title { get; set;}

//     public static List<Apod> GetApodCall()
//     {
//       var apiCallTask = ApiHelper.GetAll;
//       var result = apiCallTask.Result;


//     JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
//     List<Apod> apodList = JsonConvert.DeserializeObject<List<Apod>>(jsonResponse.ToString());

//     return ApodList
//     }
//   }
  
//   }
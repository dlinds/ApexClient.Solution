using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApexClient.Models
{
  public class Application
  {

    public Guid ApplicationId { get; set; }
    public string Manufacturer { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }

    public static List<Application> GetApplications(string name, string manufacturer, string version)
    {
      var apiCallTask = ApexApiHelper.Application.GetAll(name, manufacturer, version);
      var result = apiCallTask.Result;
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Application> applicationList = JsonConvert.DeserializeObject<List<Application>>(jsonResponse.ToString());

      return applicationList;
    }


  }
}

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

    public static List<Application> GetApplications(string name = "", string manufacturer = "", string version = "")
    {
      var apiCallTask = ApexApiHelper.ApplicationMethods.GetAll(name, manufacturer, version);
      var result = apiCallTask.Result;
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Application> applicationList = JsonConvert.DeserializeObject<List<Application>>(jsonResponse.ToString());

      return applicationList;
    }

    public static Application GetApplicationById(string applicationId)
    {
      var apiCallTask = ApexApiHelper.ApplicationMethods.GetApplicationById(applicationId);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Application application = JsonConvert.DeserializeObject<Application>(jsonResponse.ToString());
      return application;
    }

    public static string CreateApplication(Application application)
    {

      var apiCallTask = ApexApiHelper.ApplicationMethods.CreateApplication(application);
      string newApplicationId = apiCallTask.Result;
      return newApplicationId.Trim('"');
    }

  }
}

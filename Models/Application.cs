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
      var apiCallTask = ApplicationApiHelper.GetAll(name, manufacturer, version);
      var result = apiCallTask.Result;
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Application> applicationList = JsonConvert.DeserializeObject<List<Application>>(jsonResponse.ToString());

      return applicationList;
    }
    // public static Animal GetDetails(int id)
    // {
    //   var apiCallTask = AnimalApiHelper.GetDetails(id);
    //   var result = apiCallTask.Result;

    //   JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
    //   Animal animal = JsonConvert.DeserializeObject<Animal>(jsonResponse.ToString());

    //   return animal;
    // }
    // public static List<string> GetBreeds()
    // {
    //   var apiCallTask = AnimalApiHelper.GetBreeds();
    //   var result = apiCallTask.Result;

    //   JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
    //   List<string> breedList = JsonConvert.DeserializeObject<List<string>>(jsonResponse.ToString());

    //   return breedList;
    // }
    // public static List<string> GetSpecies()
    // {
    //   var apiCallTask = AnimalApiHelper.GetSpecies();
    //   var result = apiCallTask.Result;

    //   JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
    //   List<string> speciesList = JsonConvert.DeserializeObject<List<string>>(jsonResponse.ToString());

    //   return speciesList;
    // }
    // public static void Post(Animal animal)
    // {
    //   string jsonAnimal = JsonConvert.SerializeObject(animal);
    //   var apiCallTask = AnimalApiHelper.Post(jsonAnimal);
    // }

    // public static void Put(Animal animal)
    // {
    //   string jsonAnimal = JsonConvert.SerializeObject(animal);
    //   var apiCallTask = AnimalApiHelper.Put(animal.AnimalId, jsonAnimal);
    // }

    // public static void Delete(int id)
    // {
    //   var apiCallTask = AnimalApiHelper.Delete(id);
    // }
  }
}

using System.Threading.Tasks;
using RestSharp;
using System;

namespace ApexClient.Models
{
  class ApexApiHelper
  {
    public class Application
    {
      public static async Task<string> GetAll(string name, string manufacturer, string version)
      {
        RestClient client = new RestClient("https://localhost:5000/api");
        RestRequest request = new RestRequest($"applications/find?name={name}&manufacturer={manufacturer}&version={version}", Method.GET);
        var response = await client.ExecuteTaskAsync(request);
        // Console.WriteLine(response.Content);
        return response.Content;
      }

    }

    public class Command
    {
      public static async Task<string> GetAll(string searchTerm, string appName, string submissionText)
      {
        RestClient client = new RestClient("https://localhost:5000/api");
        RestRequest request = new RestRequest($"command/find?searchTerm={searchTerm}&appName={appName}&submissionText={submissionText}", Method.GET);
        var response = await client.ExecuteTaskAsync(request);
        // Console.WriteLine(response.Content);
        return response.Content;
      }

      public static async Task<string> GetCommandsByAppId(string applicationId)
      {
        RestClient client = new RestClient("https://localhost:5000/api");
        RestRequest request = new RestRequest($"commands/appId?id={applicationId}", Method.GET);
        var response = await client.ExecuteTaskAsync(request);
        // Console.WriteLine(response.Content);
        return response.Content;
      }
    }
  }
}

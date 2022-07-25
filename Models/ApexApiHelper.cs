using System.Threading.Tasks;
using RestSharp;
using System;

namespace ApexClient.Models
{
  class ApexApiHelper
  {
    private static Uri Api_Uri = new Uri("https://localhost:5000/api");
    public class ApplicationMethods
    {
      public static async Task<string> GetAll(string name, string manufacturer, string version)
      {
        RestClient client = new RestClient(Api_Uri);
        RestRequest request = new RestRequest($"applications/find?name={name}&manufacturer={manufacturer}&version={version}", Method.GET);
        var response = await client.ExecuteTaskAsync(request);
        return response.Content;
      }

      public static async Task<string> GetApplicationById(string appId)
      {
        RestClient client = new RestClient(Api_Uri);
        RestRequest request = new RestRequest($"applications/{appId}", Method.GET);
        var response = await client.ExecuteTaskAsync(request);
        return response.Content;
      }

      public static async Task<string> CreateApplication(Application application)
      {
        RestClient client = new RestClient(Api_Uri);
        RestRequest request = new RestRequest($"applications/add", Method.POST);
        request.AddQueryParameter("manufacturer", application.Manufacturer);
        request.AddQueryParameter("name", application.Name);
        request.AddQueryParameter("version", application.Version);
        var response = await client.ExecuteTaskAsync(request);
        return response.Content;
      }

    }

    public class CommandMethods
    {
      public static async Task<string> GetAll(string searchTerm, string appName, string submissionText)
      {
        RestClient client = new RestClient(Api_Uri);
        RestRequest request = new RestRequest($"command/find?searchTerm={searchTerm}&appName={appName}&submissionText={submissionText}", Method.GET);
        var response = await client.ExecuteTaskAsync(request);
        // Console.WriteLine(response.Content);
        return response.Content;
      }

      public static async Task<string> GetCommandsByAppId(string applicationId)
      {
        RestClient client = new RestClient(Api_Uri);
        RestRequest request = new RestRequest($"commands/appId?id={applicationId}", Method.GET);
        var response = await client.ExecuteTaskAsync(request);
        return response.Content;
      }

      public static async Task<string> GetCommandById(string commandId)
      {
        RestClient client = new RestClient(Api_Uri);
        RestRequest request = new RestRequest($"commands/{commandId}", Method.GET);
        var response = await client.ExecuteTaskAsync(request);
        return response.Content;
      }

      public static async Task<string> CreateCommand(string applicationId, string keyword, string shortcut)
      {
        RestClient client = new RestClient(Api_Uri);
        RestRequest request = new RestRequest($"commands/add?applicationId={applicationId}&keyword={keyword}&shortcut={shortcut}", Method.POST);
        var response = await client.ExecuteTaskAsync(request);
        return response.Content;
      }

      public static async Task<string> EditCommand(string commandId, string keyword, string shortcut)
      {
        RestClient client = new RestClient(Api_Uri);
        RestRequest request = new RestRequest($"commands/{commandId}", Method.PUT);
        request.AddJsonBody(new
        {
          commandId = commandId,
          shortcut = shortcut,
          keyword = keyword
        });
        var response = await client.ExecuteTaskAsync(request);
        return response.Content;
      }

    }
  }
}

using System.Threading.Tasks;
using RestSharp;
using System;

namespace ApexClient.Models
{
  class ApplicationApiHelper
  {
    public static async Task<string> GetAll(string name, string manufacturer, string version)
    {
      Console.WriteLine("API Helpdr");
      RestClient client = new RestClient("https://localhost:5000/api");
      RestRequest request = new RestRequest($"applications/find?name={name}&manufacturer={manufacturer}&version={version}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      Console.WriteLine(response.Content);
      return response.Content;
    }
  }
}

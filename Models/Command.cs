using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApexClient.Models
{
  public class Command
  {

    public Guid CommandId { get; set; }
    public string Keyword { get; set; }
    public string Shortcut { get; set; }
    public int CallCount { get; set; }
    public virtual Application Application { get; set; }

    public static List<Command> GetCommand(string searchTerm, string appName, string submissionText)
    {
      var apiCallTask = ApexApiHelper.Command.GetAll(searchTerm, appName, submissionText);
      var result = apiCallTask.Result;
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Command> commandList = JsonConvert.DeserializeObject<List<Command>>(jsonResponse.ToString());

      return commandList;
    }

    public static List<Command> GetCommandsByAppId(string applicationId)
    {
      var apiCallTask = ApexApiHelper.Command.GetCommandsByAppId(applicationId);
      var result = apiCallTask.Result;
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Command> commandList = JsonConvert.DeserializeObject<List<Command>>(jsonResponse.ToString());
      return commandList;
    }

  }
}

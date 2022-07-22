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
      var apiCallTask = ApexApiHelper.CommandMethods.GetAll(searchTerm, appName, submissionText);
      var result = apiCallTask.Result;
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Command> commandList = JsonConvert.DeserializeObject<List<Command>>(jsonResponse.ToString());

      return commandList;
    }

    public static List<Command> GetCommandsByAppId(string applicationId)
    {
      var apiCallTask = ApexApiHelper.CommandMethods.GetCommandsByAppId(applicationId);
      var result = apiCallTask.Result;
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Command> commandList = JsonConvert.DeserializeObject<List<Command>>(jsonResponse.ToString());
      return commandList;
    }

    public static Command GetCommandById(string commandId)
    {
      var apiCallTask = ApexApiHelper.CommandMethods.GetCommandById(commandId);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Command command = JsonConvert.DeserializeObject<Command>(jsonResponse.ToString());
      return command;
    }

    public static bool CreateCommand(string applicationId, string keyword, string shortcut)
    {
      try
      {
        var apiCallTask = ApexApiHelper.CommandMethods.CreateCommand(applicationId, keyword, shortcut);
        var result = apiCallTask.Result;
        return true;
      }
      catch
      {
        return false;
      }
    }

    public static bool EditCommand(string commandId, string keyword, string shortcut)
    {
      try
      {
        var apiCallTask = ApexApiHelper.CommandMethods.EditCommand(commandId, keyword, shortcut);
        var result = apiCallTask.Result;
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}

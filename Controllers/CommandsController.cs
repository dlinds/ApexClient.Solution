using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ApexClient.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System;
using System.Web;

namespace ApexClient.Controllers
{
  public class CommandsController : Controller
  {
    public ActionResult LoadCommandsByAppId(string applicationId)
    {
      try
      {
        List<Command> commandList = Command.GetCommandsByAppId(applicationId).OrderByDescending(x => x.CallCount).ToList();
        ViewData["commandList"] = commandList;
        ViewData["applicationId"] = Application.GetApplicationById(applicationId);
        return PartialView("~/Views/Applications/Partial/_ApplicationDetail.cshtml");
      }
      catch
      {
        return NotFound("didn't find anything");
      }
    }

    public ActionResult LoadNewEditCommandForm(string applicationId, string commandId)
    {
      try
      {
        Application application = Application.GetApplicationById(applicationId);
        if (application.Name == null) throw new Exception("No application was found");
        ViewData["application"] = application;
        ViewData["command"] = (commandId != null) ? Command.GetCommandById(commandId) : null;
        return PartialView("~/Views/Applications/Partial/_NewCommand.cshtml");
      }
      catch (Exception e)
      {
        return NotFound(e.Message);
      }
    }

    [HttpGet]
    public ActionResult Create()
    {
      ViewBag.Applications = Application.GetApplications();
      return View();
    }

    [HttpPost]
    public ActionResult CreateNewCommand(string applicationId, string keyword, string shortcut, string commandId = null)
    {
      // shortcut = HttpUtility.UrlEncode(shortcut);
      try
      {
        Application application = Application.GetApplicationById(applicationId);
        if (application.Name == null) throw new Exception("No application was found");
        if (commandId == null)
        {
          Command.CreateCommand(applicationId, keyword, HttpUtility.UrlEncode(shortcut));
        }
        else
        {
          Command.EditCommand(commandId, keyword, HttpUtility.UrlEncode(shortcut));
        }
        return Ok();
      }
      catch (Exception e)
      {
        return NotFound(e.Message);
      }
    }

  }
}

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

namespace ApexClient.Controllers
{
  public class CommandsController : Controller
  {
    public ActionResult LoadCommandsByAppId(string applicationId)
    {
      try
      {
        List<Command> commandList = Command.GetCommandsByAppId(applicationId).OrderBy(x => x.CallCount).ToList();
        ViewData["commandList"] = commandList;
        return PartialView("~/Views/Applications/Partial/_ApplicationDetail.cshtml");
      }
      catch
      {
        return NotFound("didn't find anything");
      }
    }



  }
}

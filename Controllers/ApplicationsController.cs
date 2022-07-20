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
  public class ApplicationsController : Controller
  {
    public IActionResult Index(string name, string manufacturer, string version)
    {
      try
      {
        var allApplications = Application.GetApplications(name, manufacturer, version);
        if (allApplications.Count == 0) throw new Exception();
        ViewBag.Manufacturers = allApplications.Select(x => x.Manufacturer).Distinct().ToList();
        ViewBag.Applications = allApplications.Select(x => x.Name).Distinct().ToList();
        ViewBag.Versions = allApplications.Select(x => x.Version).Distinct().ToList();
        return View(allApplications);
      }
      catch
      {
        return NotFound();
      }
    }

    public ActionResult LoadApplicationSearchResults(string name, string manufacturer, string version)
    {
      try
      {
        var allApplications = Application.GetApplications(name, manufacturer, version);
        if (allApplications.Count == 0) throw new Exception();
        ViewData["applicationList"] = allApplications;
        return PartialView("~/Views/Applications/Partial/_ApplicationTiles.cshtml");
      }
      catch
      {
        return NotFound("didn't find anything");
      }
    }

  }
}

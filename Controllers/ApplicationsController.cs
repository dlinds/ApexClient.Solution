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
      var allApplications = Application.GetApplications(name, manufacturer, version);
      ViewBag.Manufacturers = allApplications.Select(x => x.Manufacturer).Distinct().ToList();
      ViewBag.Applications = allApplications.Select(x => x.Name).Distinct().ToList();
      ViewBag.Versions = allApplications.Select(x => x.Version).Distinct().ToList();
      return View(allApplications);
    }

    // public IActionResult Details(int id)
    // {
    //   var thisAnimal = Animal.GetDetails(id);
    //   return View(thisAnimal);
    // }
    // public ActionResult Create()
    // {
    //   return View();
    // }
    // [HttpPost]
    // public IActionResult Create(Animal animal)
    // {
    //   Animal.Post(animal);
    //   return RedirectToAction("Index");
    // }

    // public IActionResult Edit(int id)
    // {
    //   var thisAnimal = Animal.GetDetails(id);
    //   return View(thisAnimal);
    // }

    // [HttpPost]
    // public IActionResult Edit(Animal animal)
    // {
    //   Animal.Put(animal);
    //   return RedirectToAction("Index");
    // }

    // [HttpPost]
    // public IActionResult Delete(int id)
    // {
    //   Animal.Delete(id);
    //   return RedirectToAction("Index");
    // }
  }
}
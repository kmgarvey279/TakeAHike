using Microsoft.AspNetCore.Mvc;
using TakeAHike.Models;
using System.Collections.Generic;
using System;

namespace TakeAHike.Controllers
{
  public class TrailsController : Controller
  {
    [Route("/trails")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/trails/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/trails/create")]
    public ActionResult Create()
    {
      Trails.Save();
      Trails.GetAll();
      return View("Show");
    }

  }
}

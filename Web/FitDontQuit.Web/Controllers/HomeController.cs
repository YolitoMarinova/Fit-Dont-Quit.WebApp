﻿namespace FitDontQuit.Web.Controllers
{
    using System.Diagnostics;

    using FitDontQuit.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public IActionResult HttpError(int statusCode)
        {
            if (statusCode == 404)
            {
                return this.View("NotFound");
            }

            return this.RedirectToAction("Error");
        }
    }
}

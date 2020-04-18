using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitDontQuit.Web.Controllers
{
    public class GroupTrainingsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

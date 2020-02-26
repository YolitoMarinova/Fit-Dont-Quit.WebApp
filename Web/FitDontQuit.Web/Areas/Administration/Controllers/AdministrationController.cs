namespace FitDontQuit.Web.Areas.Administration.Controllers
{
    using FitDontQuit.Common;
    using FitDontQuit.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}

namespace FitDontQuit.Web.Controllers
{
    using System.Linq;

    using FitDontQuit.Services.Data;
    using FitDontQuit.Web.ViewModels.Memberships;
    using Microsoft.AspNetCore.Mvc;

    public class MembershipsController : BaseController
    {
        private readonly IMembershipsService membershipsService;

        public MembershipsController(IMembershipsService membershipsService)
        {
            this.membershipsService = membershipsService;
        }

        public IActionResult Index()
        {
            var memberships = this.membershipsService.GettAll<MembershipViewModel>().ToList();

            return this.View(memberships);
        }
    }
}

using FitDontQuit.Data.Models;
using FitDontQuit.Services.Messaging;
using FitDontQuit.Web.ViewModels.Contacts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitDontQuit.Web.Controllers
{
    public class ContactsController : BaseController
    {
        private readonly IEmailSender emailSender;
        private readonly UserManager<ApplicationUser> userManager;

        public ContactsController(IEmailSender emailSender, UserManager<ApplicationUser> userManager)
        {
            this.emailSender = emailSender;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.Identity.IsAuthenticated == true)
            {
                var user = await this.userManager.GetUserAsync(this.User);
                var email = await this.userManager.GetEmailAsync(user);

                var viewModel = new ContactsInputModel { Email = email };

                return this.View(viewModel);
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(ContactsInputModel inputModel)
        {
            await this.emailSender.SendEmailAsync(inputModel.Email, inputModel.Name, "fitness.fitdontquit@gmail.com", "Contact request", inputModel.Content);

            return this.RedirectToAction("Index");
        }
    }
}

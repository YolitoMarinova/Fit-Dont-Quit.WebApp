using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Linq;
using System.Threading.Tasks;
using FitDontQuit.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using FitDontQuit.Services.Data;

namespace FitDontQuit.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class MembershipModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPurchasedMembershipsService purchasedMembershipsService;

        public MembershipModel(UserManager<ApplicationUser> userManager, IPurchasedMembershipsService purchasedMembershipsService)
        {
            this.userManager = userManager;
            this.purchasedMembershipsService = purchasedMembershipsService;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int MembershipDuration { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        private async Task LoadAsync(ApplicationUser user)
        {
            var purchase = this.purchasedMembershipsService.GetByUser(user);

            if (purchase == null)
            {
                return;
            }

            this.Name = purchase.MembershipName;
            this.Price = purchase.MembershipPrice;
            this.StartDate = purchase.StartDate;
            this.EndDate = purchase.EndDate;
            this.MembershipDuration = purchase.MembershipDuration;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await this.userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{this.userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        //public async Task<IActionResult> OnPostChangeEmailAsync()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        await LoadAsync(user);
        //        return Page();
        //    }

        //    var email = await _userManager.GetEmailAsync(user);
        //    if (Input.NewEmail != email)
        //    {
        //        var userId = await _userManager.GetUserIdAsync(user);
        //        var code = await _userManager.GenerateChangeEmailTokenAsync(user, Input.NewEmail);
        //        var callbackUrl = Url.Page(
        //            "/Account/ConfirmEmailChange",
        //            pageHandler: null,
        //            values: new { userId = userId, email = Input.NewEmail, code = code },
        //            protocol: Request.Scheme);
        //        await _emailSender.SendEmailAsync(
        //            Input.NewEmail,
        //            "Confirm your email",
        //            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        //        StatusMessage = "Confirmation link to change email sent. Please check your email.";
        //        return RedirectToPage();
        //    }

        //    StatusMessage = "Your email is unchanged.";
        //    return RedirectToPage();
        //}
        
    }
}

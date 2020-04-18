// ReSharper disable VirtualMemberCallInConstructor
namespace FitDontQuit.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Data.Common.Models;
    using Microsoft.AspNetCore.Identity;

    using static FitDontQuit.Common.AttributesConstraints.User;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.PurchasedMemberships = new HashSet<PurchasedMembership>();
            this.PurchasedServices = new HashSet<PurchasedServices>();
            this.Articles = new HashSet<Article>();
        }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string LastName { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual IEnumerable<PurchasedMembership> PurchasedMemberships { get; set; }

        public virtual IEnumerable<PurchasedServices> PurchasedServices { get; set; }

        public virtual IEnumerable<Article> Articles { get; set; }
    }
}

// ReSharper disable VirtualMemberCallInConstructor
namespace FitDontQuit.Data.Models
{
    using FitDontQuit.Data.Common.Models;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.GroupTrainings = new HashSet<UsersGroupTrainings>();
            this.PurchasedMemberships = new HashSet<PurchasedMembership>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual IEnumerable<UsersGroupTrainings> GroupTrainings { get; set; }

        public virtual IEnumerable<PurchasedMembership> PurchasedMemberships { get; set; }
    }
}

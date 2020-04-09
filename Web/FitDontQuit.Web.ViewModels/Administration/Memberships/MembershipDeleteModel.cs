namespace FitDontQuit.Web.ViewModels.Administration.Memberships
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Memberships;

    public class MembershipDeleteModel : IMapFrom<MembershipServiceOutputModel>
    {
        public int Id { get; set; }
    }
}

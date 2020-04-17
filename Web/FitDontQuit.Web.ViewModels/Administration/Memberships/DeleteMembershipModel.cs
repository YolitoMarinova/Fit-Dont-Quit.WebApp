using FitDontQuit.Services.Mapping;
using FitDontQuit.Services.Models.Memberships;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitDontQuit.Web.ViewModels.Administration.Memberships
{
    public class DeleteMembershipModel : IMapFrom<MembershipServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

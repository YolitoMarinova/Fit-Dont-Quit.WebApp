namespace FitDontQuit.Web.ViewModels.Administration.Memberships
{
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Memberships;

    public class DeleteMembershipModel : IMapFrom<MembershipServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

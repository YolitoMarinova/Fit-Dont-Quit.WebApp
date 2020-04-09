namespace FitDontQuit.Web.ViewModels.Memberships
{
    using FitDontQuit.Data.Models.Enums;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Memberships;

    public class PurchasedMembershipModel : IMapFrom<MembershipServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Duration Duration { get; set; }
    }
}

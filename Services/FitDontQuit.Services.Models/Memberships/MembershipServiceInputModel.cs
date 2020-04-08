namespace FitDontQuit.Services.Models.Memberships
{
    using FitDontQuit.Data.Models;
    using FitDontQuit.Data.Models.Enums;
    using FitDontQuit.Services.Mapping;

    public class MembershipServiceInputModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Duration Duration { get; set; }
    }
}

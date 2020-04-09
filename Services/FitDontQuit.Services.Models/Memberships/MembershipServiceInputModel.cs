namespace FitDontQuit.Services.Models.Memberships
{


    using FitDontQuit.Data.Models.Enums;

    public class MembershipServiceInputModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Duration Duration { get; set; }

        public bool HaveATrainer { get; set; }

        public AmountOfPeopleLimit AmountOfPeopleLimit { get; set; }

        public VisitLimit VisitLimit { get; set; }
    }
}

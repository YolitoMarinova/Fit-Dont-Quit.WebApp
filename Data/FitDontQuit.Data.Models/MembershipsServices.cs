namespace FitDontQuit.Data.Models
{
    public class MembershipsServices
    {
        public int MembershipId { get; set; }

        public virtual Membership Membership { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}

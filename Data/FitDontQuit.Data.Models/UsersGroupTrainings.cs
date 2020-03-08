namespace FitDontQuit.Data.Models
{
    public class UsersGroupTrainings
    {
        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int GroupTrainingId { get; set; }

        public virtual GroupTraining GroupTraining { get; set; }
    }
}

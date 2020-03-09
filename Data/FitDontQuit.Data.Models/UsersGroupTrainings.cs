namespace FitDontQuit.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UsersGroupTrainings
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int GroupTrainingId { get; set; }

        public virtual GroupTraining GroupTraining { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WzimTrainingClub.Models
{
    public class WorkoutSession
    {
        [Required(ErrorMessage = "Uzupełnij to pole.")]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Uzupełnij to pole.")]
        [Range(1, 28)]
        public int DayNumber { get; set; } = 1;

        public WorkoutActivity[] Activities { get; set; }
    }
}

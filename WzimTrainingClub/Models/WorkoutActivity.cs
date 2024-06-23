using System.ComponentModel.DataAnnotations;

namespace WzimTrainingClub.Models
{
    public class WorkoutActivity
    {
        [Required(ErrorMessage = "Uzupełnij to pole.")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        [MaxLength(30)]
        public string Quantity { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        [Range(1, 100)]
        public int Sets { get; set; } = 1;

        public int RestPeriodSeconds { get; set; } = 0;
    }
}

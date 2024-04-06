using System.ComponentModel.DataAnnotations;

namespace WzimTrainingClub.Models
{
    public class WorkoutActivity
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Quantity { get; set; }

        [Required]
        [Range(1, 100)]
        public int Sets { get; set; } = 1;

        public int RestPeriodSeconds { get; set; } = 0;
    }
}

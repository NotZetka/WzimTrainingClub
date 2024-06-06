using System.ComponentModel.DataAnnotations;

namespace WzimTrainingClub.Models
{
    public class DailyNutrition
    {
        public long ID { get; set; }

        [Required]
        public AppUser User { get; set; }

        [Required]
        public int DailyCalories { get; set; }

        [Required]
        public int DailyCarbohydrates { get; set; }

        [Required]
        public int DailyProtein { get; set; }

        [Required]
        public int DailyFat { get; set; }

    }
}

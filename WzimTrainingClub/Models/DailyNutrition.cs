using System.ComponentModel.DataAnnotations;

namespace WzimTrainingClub.Models
{
    public class DailyNutrition
    {
        public long ID { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        public AppUser User { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        public int DailyCalories { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        public int DailyCarbohydrates { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        public int DailyProtein { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        public int DailyFat { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WzimTrainingClub.Models
{
    public class FoodRecord
    {
        public long ID { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        public AppUser User { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        [ForeignKey("Food")]
        public long FoodID { get; set; }

        public Food Food { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        public DateTime ConsumptionDate { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        public float Quantity { get; set; }
    }
}

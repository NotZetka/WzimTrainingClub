using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WzimTrainingClub.Models
{
    public class FoodRecord
    {
        public long ID { get; set; }

        [Required]
        public AppUser User { get; set; }

        [Required]
        [ForeignKey("Food")]
        public long FoodID { get; set; }

        public Food Food { get; set; }

        [Required]
        public DateTime ConsumptionDate { get; set; }

        [Required]
        public float Quantity { get; set; }
    }
}

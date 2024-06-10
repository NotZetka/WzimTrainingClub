using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WzimTrainingClub.Models.Enums;

namespace WzimTrainingClub.Models
{
    public class Food
    {
        public long ID { get; set; }

        [Required]
        [ForeignKey("CreatedBy")]
        public string CreatedByID { get; set; }

        public AppUser CreatedBy { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Calories { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Carbohydrates { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Protein { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Fat { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ServingSize { get; set; }

        [Required]
        public PortionUnit PortionUnit { get; set; }

        [Required]
        public DateTime ConsumptionDate { get; set; }
    }
}

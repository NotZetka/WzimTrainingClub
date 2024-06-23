using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WzimTrainingClub.Models.Enums;

namespace WzimTrainingClub.Models
{
    public class Food
    {
        public long ID { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        [ForeignKey("CreatedBy")]
        public string CreatedByID { get; set; }

        public AppUser CreatedBy { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        [Range(0, int.MaxValue)]
        public int Calories { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        [Range(0, int.MaxValue)]
        public int Carbohydrates { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        [Range(0, int.MaxValue)]
        public int Protein { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        [Range(0, int.MaxValue)]
        public int Fat { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        [Range(0, int.MaxValue)]
        public int ServingSize { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        public PortionUnit PortionUnit { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        public DateTime ConsumptionDate { get; set; }
    }
}

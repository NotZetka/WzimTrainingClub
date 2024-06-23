using System.ComponentModel.DataAnnotations.Schema;

namespace WzimTrainingClub.Models
{
    public class TargetBodyweight
    {
        public long ID { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser User { get; set; }
        public float TargetWeight { get; set; }
        public DateTime TargetDate { get; set; }
    }
}

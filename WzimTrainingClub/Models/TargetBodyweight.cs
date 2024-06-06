namespace WzimTrainingClub.Models
{
    public class TargetBodyweight
    {
        public long ID { get; set; }
        public AppUser User { get; set; }
        public float TargetWeight { get; set; }
        public DateTime TargetDate { get; set; }
    }
}

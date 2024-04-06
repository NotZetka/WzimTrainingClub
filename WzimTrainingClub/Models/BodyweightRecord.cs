namespace WzimTrainingClub.Models
{
    public class BodyweightRecord
    {
        public long ID { get; set; }
        public AppUser User { get; set; }
        public DateTime Date { get; set; }
        public float Weight { get; set; }
    }
}

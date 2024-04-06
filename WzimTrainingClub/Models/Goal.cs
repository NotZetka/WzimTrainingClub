namespace WzimTrainingClub.Models
{
    public class Goal
    {
        public long ID { get; set; }
        public AppUser User { get; set; }
        public string Activity { get; set; }
    }
}

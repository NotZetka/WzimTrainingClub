namespace WzimTrainingClub.Models
{
    public class TimedGoal : Goal
    {
        public TimeSpan Time { get; set; }
        public float Quantity { get; set; }
        public string QuantityUnit { get; set; }
    }
}

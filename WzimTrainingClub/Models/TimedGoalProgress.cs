using System.ComponentModel.DataAnnotations.Schema;

namespace WzimTrainingClub.Models
{
    public class TimedGoalProgress : GoalProgress
    {
        public float Quantity { get; set; }

        [NotMapped]
        public string QuantityUnit { get { return ((TimedGoal)this.Goal).QuantityUnit; } }

        public TimeSpan Time { get; set; }
    }
}

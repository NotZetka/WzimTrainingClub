using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace WzimTrainingClub.Models
{
    public class WorkoutPlan
    {
        public long ID { get; set; }

        [Required]
        public AppUser User { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SessionsJSON { get; set; }

        [NotMapped]
        public WorkoutSession[] Sessions
        {
            get
            {
                if (string.IsNullOrEmpty(SessionsJSON))
                    return new WorkoutSession[0];
                return JsonSerializer.Deserialize<WorkoutSession[]>(this.SessionsJSON);
            }
        }
    }
}

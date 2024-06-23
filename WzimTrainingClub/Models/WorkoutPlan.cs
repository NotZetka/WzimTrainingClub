using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace WzimTrainingClub.Models
{
    public class WorkoutPlan
    {
        public long ID { get; set; }

        [Required(ErrorMessage = "Uzupełnij to pole.")]
        public AppUser User { get; set; }
        [Required(ErrorMessage = "Uzupełnij to pole.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Uzupełnij to pole.")]
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

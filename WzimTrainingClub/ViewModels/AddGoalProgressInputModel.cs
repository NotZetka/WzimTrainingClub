using System.ComponentModel.DataAnnotations;

namespace WzimTrainingClub.ViewModels;

public class AddGoalProgressInputModel
{
    [Required(ErrorMessage = "Uzupełnij to pole.")]
    [Range(0,long.MaxValue)]
    public long GoalID { get; set; }
    [Required(ErrorMessage = "Uzupełnij to pole.")]
    [MaxLength(20)]
    public string Type { get; set; }
    [Required(ErrorMessage = "Uzupełnij to pole.")]
    public DateTime Date { get; set; }
    [Range(0,500)]
    public float Weight { get; set; }
    [Range(0,100)]
    public int Reps { get; set; }
    [Range(0,int.MaxValue)]
    public int Quantity { get; set; }
    [Range(0, 24)]
    public int Hours { get; set; }
    [Range(0,60)]
    public int Minutes { get; set; }
    [Range(0,60)]
    public int Seconds { get; set; }
}
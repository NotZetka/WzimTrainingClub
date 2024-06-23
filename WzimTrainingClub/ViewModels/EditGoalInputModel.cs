using System.ComponentModel.DataAnnotations;

namespace WzimTrainingClub.ViewModels;

public class EditGoalInputModel
{
    [Range(0,double.MaxValue)]
    public int ID { get; set; }
    [Required(ErrorMessage = "Nazwa aktywności jest wymagana")]
    [MaxLength(30, ErrorMessage = "Nazwa aktywności nie może mieć więcej niż 30 znaków")]
    public string Activity { get; set; }
    [Required(ErrorMessage = "Typ aktywności jest wymagany")]
    [MaxLength(20, ErrorMessage = "Typ aktywności nie może mieć wiecej niż 20 znaków")]
    public string Type { get; set; }
    [Range(0,500, ErrorMessage = "Waga musi być większa od 0 i mniejsza od 500")]
    public float Weight { get; set; }
    [Range(0,100, ErrorMessage = "Ilość powtórzeń musi być większa od 0 i mniejsza od 100")]
    public int Reps { get; set; }
    [Range(0,24, ErrorMessage = "Godzina musi być w przedziale od 0 do 24")]
    public int Hours { get; set; }
    [Range(0,60, ErrorMessage = "Minuty muszą być w przedziale od 0 do 60")]
    public int Minutes { get; set; }
    [Range(0,60, ErrorMessage = "Sekundy muszą być w przedziale od 0 do 60")]
    public int Seconds { get; set; }
    [Range(0,double.MaxValue)]
    public float Quantity { get; set; }
    [MaxLength(30, ErrorMessage = "Jednostka nie może mieć więcej niż 30 znaków")]
    public string? QuantityUnit { get; set; }
}
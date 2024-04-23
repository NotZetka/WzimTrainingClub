using WzimTrainingClub.Models;

namespace WzimTrainingClub.ViewModels;

public class GoalViewModel
{
    public Goal Goal { get; set; }
    public GoalProgress[] Progress { get; set; }
}
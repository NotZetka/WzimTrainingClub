using WzimTrainingClub.Models;

namespace WzimTrainingClub.Data
{
    public interface IGoalStorageService
    {
        public Task<Goal[]> GetAllGoals(AppUser User);
        public Task<Goal> GetGoalByID(AppUser User, long GoalID);
        public Task DeleteGoalByID(AppUser User, long GoalID);
        public Task StoreGoal(Goal Goal);
        public Task StoreGoalProgress(GoalProgress Progress);
        public Task<GoalProgress[]> GetGoalProgress(AppUser User, long GoalID, bool AscendingOrder = false);
    }
}
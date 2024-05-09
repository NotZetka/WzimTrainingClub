using WzimTrainingClub.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WzimTrainingClub.Models;
using WzimTrainingClub.ViewModels;

namespace WzimTrainingClub.Controllers
{
    [Authorize]
    public class GoalController : Controller
    {
        private IGoalStorageService storageService;
        private UserManager<AppUser> userManager;

        public GoalController(IGoalStorageService StorageService, UserManager<AppUser> UserManager)
        {
            this.storageService = StorageService;
            userManager = UserManager;
        }

        [NonAction]
        public async Task<AppUser> GetUser()
        {
            return await userManager.GetUserAsync(HttpContext.User);
        }

        [HttpGet]
        public async Task<IActionResult> Summary()
        {
            AppUser currentUser = await GetUser();

            Goal[] goals = await storageService.GetAllGoals(currentUser);

            return View(goals);
        }

        [HttpGet]
        public async Task<IActionResult> AddGoal()
        {
            WeightliftingGoal model = new WeightliftingGoal()
            {
                ID = 0
            };

            return View("editgoal", model);
        }

        [HttpGet]
        public async Task<IActionResult> EditGoal(long ID)
        {
            AppUser currentUser = await GetUser();

            Goal goal = await storageService.GetGoalByID(currentUser, ID);
            if (goal == null)
                return BadRequest();

            return View(goal);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteGoal(int ID)
        {
            AppUser currentUser = await GetUser();

            Goal goal = await storageService.GetGoalByID(currentUser, ID);
            if (goal == null)
                return BadRequest();

            await storageService.DeleteGoalByID(currentUser, ID);

            return RedirectToAction("Summary");

        }

        [HttpPost]
        public async Task<IActionResult> EditGoal(EditGoalInputModel GoalInput)
        {
            GoalInput.QuantityUnit ??= "";
            
            if (TryValidateModel(GoalInput) == false)
                return BadRequest();

            AppUser currentUser = await GetUser();

            Goal goal = null;
            if (GoalInput.ID != 0)
                goal = await storageService.GetGoalByID(currentUser, GoalInput.ID);
            else
            {
                switch (GoalInput.Type.ToLower())
                {
                    case "weightlifting":
                        goal = new WeightliftingGoal();
                        break;
                    case "timed":
                        goal = new TimedGoal();
                        break;
                }
            }

            switch (goal)
            {
                case WeightliftingGoal wGoal:
                    wGoal.Reps = GoalInput.Reps;
                    wGoal.Weight = GoalInput.Weight;
                    break;
                case TimedGoal tGoal:
                    tGoal.Quantity = (int)GoalInput.Quantity;
                    tGoal.QuantityUnit = GoalInput.QuantityUnit;
                    tGoal.Time = new TimeSpan(GoalInput.Hours, GoalInput.Minutes, GoalInput.Seconds);
                    break;
            }

            goal.Activity = GoalInput.Activity;
            goal.User = currentUser;

            await storageService.StoreGoal(goal);

            return RedirectToAction("Summary");
        }

        [HttpPost]
        public async Task<IActionResult> AddProgress(AddGoalProgressInputModel Progress)
        {
            AppUser currentUser = await GetUser();

            Goal goal = await storageService.GetGoalByID(currentUser, Progress.GoalID);
            if (goal == null)
                return BadRequest();

            GoalProgress newProgress = null;

            switch (Progress.Type.ToLower())
            {
                case "weightlifting":
                    newProgress = new WeightliftingGoalProgress()
                    {
                        Weight = Progress.Weight,
                        Reps = Progress.Reps
                    };
                    break;
                case "timed":
                    newProgress = new TimedGoalProgress()
                    {
                        Time = new TimeSpan(Progress.Hours, Progress.Minutes, Progress.Seconds),
                        Quantity = Progress.Quantity
                    };
                    break;
                default:
                    return BadRequest();
            }

            newProgress.Goal = goal;
            newProgress.Date = Progress.Date;
            newProgress.User = currentUser;

            await storageService.StoreGoalProgress(newProgress);

            return RedirectToAction("ViewGoal", new { ID = Progress.GoalID });
        }

        [HttpGet]
        public async Task<IActionResult> ViewGoal(long ID)
        {
            AppUser currentUser = await GetUser();

            Goal goal = await storageService.GetGoalByID(currentUser, ID);
            if (goal == null)
                return BadRequest();

            GoalProgress[] progress = await storageService.GetGoalProgress(currentUser, ID);

            if (progress == null)
                return BadRequest();

            GoalViewModel viewModel = new GoalViewModel()
            {
                Goal = goal,
                Progress = progress
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetWeightliftingProgress(long GoalID)
        {
            AppUser currentUser = await GetUser();

            GoalProgress[] progress = await storageService.GetGoalProgress(currentUser, GoalID, true);
            var result = Array.ConvertAll(progress, item => (WeightliftingGoalProgress)item)
                .Select(record => new { Date = record.Date.ToString("d"), Weight = record.Weight, Reps = record.Reps })
                .ToArray();

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTimedProgress(long GoalID)
        {
            AppUser currentUser = await GetUser();

            GoalProgress[] progress = await storageService.GetGoalProgress(currentUser, GoalID, true);

            var result = Array.ConvertAll(progress, item => (TimedGoalProgress)item)
                .Select(record => new { Date = record.Date.ToString("d"), Timespan = record.Time, Quantity = record.Quantity, QuantityUnit = record.QuantityUnit })
                .ToArray();

            return Json(result);
        }
    }
}
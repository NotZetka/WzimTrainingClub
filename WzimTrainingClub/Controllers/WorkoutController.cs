﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WzimTrainingClub.Data;
using WzimTrainingClub.Models;

namespace WzimTrainingClub.Controllers
{
    [Authorize]
    public class WorkoutController : Controller
    {
        private ApplicationDbContext dbContext;
        private UserManager<AppUser> userManager;

        public WorkoutController(ApplicationDbContext DBContext, UserManager<AppUser> UserManager)
        {
            dbContext = DBContext;
            userManager = UserManager;
        }

        [NonAction]
        public async Task<AppUser> GetUser()
        {
            return await userManager.GetUserAsync(User);
        }

        public async Task<IActionResult> Summary()
        {
            AppUser currentUser = await GetUser();
            WorkoutPlan[] plans = await dbContext.WorkoutPlans.Where(plan => plan.User == currentUser).ToArrayAsync();

            return View(plans);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            WorkoutPlan newPlan = new WorkoutPlan()
            {
                Name = "se"
            };
            return View("/Views/Workout/edit.cshtml", newPlan);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long ID)
        {
            WorkoutPlan plan = await dbContext.WorkoutPlans.FirstOrDefaultAsync(plan => plan.ID == ID);

            return View(plan);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WorkoutPlan WorkoutPlan)
        {
            if (WorkoutPlan.SessionsJSON == null)
            {
                WorkoutPlan.SessionsJSON = string.Empty;
            }

            AppUser currentUser = await GetUser();
            WorkoutPlan.User = currentUser;

            if (WorkoutPlan.ID == 0)
                dbContext.WorkoutPlans.Add(WorkoutPlan);
            else
                dbContext.WorkoutPlans.Update(WorkoutPlan);

            await dbContext.SaveChangesAsync();

            return RedirectToAction("Summary");
        }

        [HttpGet]
        public async Task<IActionResult> Session(long PlanID, int SessionIndex)
        {
            AppUser currentUser = await GetUser();
            WorkoutPlan plan = await dbContext.WorkoutPlans.FirstOrDefaultAsync(plan => plan.ID == PlanID && plan.User == currentUser);
            if (plan == null || SessionIndex < 0 || SessionIndex >= plan.Sessions.Length)
                return BadRequest();

            WorkoutSession session = plan.Sessions[SessionIndex];
            return View(session);
        }
    }
}
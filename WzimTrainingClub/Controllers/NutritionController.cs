﻿using WzimTrainingClub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WzimTrainingClub.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WzimTrainingClub.Controllers
{
    public class NewFoodModel
    {
        public List<Food> UserFoods { get; set; } = new List<Food>();
    }
    public class NutritionSummaryModel
    {
        public FoodRecord[] Records { get; set; }
        public DailyNutrition Target { get; set; }
    }

    [Authorize]
    public class NutritionController : Controller
    {
        private ApplicationDbContext dbContext;
        private UserManager<AppUser> userManager;

        public NutritionController(ApplicationDbContext DBContext, UserManager<AppUser> UserManager)
        {
            dbContext = DBContext;
            userManager = UserManager;
        }

        [HttpGet]
        public async Task<IActionResult> AddFood(DateTime date)
        {
            if (date.Ticks == 0)
                date = DateTime.Today;
            ViewData["selectedDate"] = date;

            AppUser currentUser = await userManager.GetUserAsync(HttpContext.User);

            NewFoodModel model = new NewFoodModel()
            {
                UserFoods = await dbContext.UserFoods.Where(record => record.CreatedBy == currentUser && record.ConsumptionDate == date).ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewFood(Food Food)
        {
            AppUser currentUser = await userManager.GetUserAsync(HttpContext.User);
            Food.CreatedBy = currentUser;

            if (Food.ID == 0)
                dbContext.UserFoods.Add(Food);
            else
                dbContext.UserFoods.Update(Food);

            await dbContext.SaveChangesAsync();

            return RedirectToAction("AddFood", Food.ConsumptionDate);
        }

        [HttpPost]
        public async Task<IActionResult> EditRecords(DateTime Date, long[] FoodIDs, float[] Quantities)
        {
            if (FoodIDs.Length != Quantities.Length || FoodIDs.Length == 0)
                return BadRequest();

            AppUser currentUser = await userManager.GetUserAsync(HttpContext.User);

            FoodRecord[] existingRecords = await dbContext.FoodRecords.Where(record => record.User == currentUser && record.ConsumptionDate == Date).ToArrayAsync();
            dbContext.FoodRecords.RemoveRange(existingRecords);

            FoodRecord[] newRecords = new FoodRecord[FoodIDs.Length];
            for (int i = 0; i < FoodIDs.Length; i++)
            {
                newRecords[i] = new FoodRecord()
                {
                    ConsumptionDate = Date,
                    User = currentUser,
                    FoodID = FoodIDs[i],
                    Quantity = Quantities[i]
                };
            }
            dbContext.FoodRecords.AddRange(newRecords);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("AddFood", Date);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFood(long ID)
        {
            AppUser currentUser = await userManager.GetUserAsync(HttpContext.User);

            Food targetFood = await dbContext.UserFoods.FirstOrDefaultAsync(food => food.ID == ID);
            if (targetFood == null || targetFood.CreatedBy != currentUser)
                return BadRequest();

            dbContext.UserFoods.Remove(targetFood);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("AddFood", targetFood.ConsumptionDate);
        }

        [HttpGet]
        public async Task<IActionResult> Summary()
        {
            AppUser currentUser = await userManager.GetUserAsync(HttpContext.User);

            FoodRecord[] userRecords = await dbContext.UserFoods
                .Where(record => record.CreatedBy == currentUser && record.ConsumptionDate >= DateTime.Today.AddDays(-28))
                .Select(x=> new FoodRecord
                {
                    ConsumptionDate = x.ConsumptionDate,
                    Food = x,
                    User = x.CreatedBy,
                    Quantity = x.ServingSize,
                })
                .ToArrayAsync();
            DailyNutrition userTarget = await dbContext.DailyNutritions.FirstOrDefaultAsync(record => record.User == currentUser);
            if (userTarget == null)
                userTarget = new DailyNutrition();

            NutritionSummaryModel summaryModel = new NutritionSummaryModel()
            {
                Records = userRecords,
                Target = userTarget
            };

            return View(summaryModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetNutritionData(uint PreviousDays = 7)
        {
            AppUser currentUser = await userManager.GetUserAsync(HttpContext.User);

            if(currentUser == null)
            {
                return BadRequest();
            }

            var records = await dbContext.UserFoods
                .Where(record => record.ConsumptionDate >= DateTime.Today.AddDays(-PreviousDays) && record.CreatedByID == currentUser.Id)
                .OrderBy(record => record.ConsumptionDate)
                .ToArrayAsync();

            var result = records
                .GroupBy(record => record.ConsumptionDate)
                .Select(grouping => new
                {
                    Date = grouping.Key.ToString("d"),
                    Calories = grouping.Sum(r => r.Calories),
                    Carbs = grouping.Sum(r => r.Carbohydrates),
                    Protein = grouping.Sum(r => r.Protein),
                    Fat = grouping.Sum(r => r.Fat)
                })
                .ToArray();

            //var result = records
            //.GroupBy(record => record.ConsumptionDate)
            //.Select(grouping =>
            //new
            //{
            //    Data = grouping.Key.ToString("d"),
            //    Kcal = grouping.Sum(r => r.Food.Calories),
            //    Węglowodany = grouping.Sum(r => r.Food.Carbohydrates),
            //    Białko = grouping.Sum(r => r.Food.Protein),
            //    Tłuszcz = grouping.Sum(r => r.Food.Fat)
            //})
            //.ToArray();

            return Json(result);
        }
    }


}
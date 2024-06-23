using WzimTrainingClub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WzimTrainingClub.Data;
using WzimTrainingClub.ViewModels;

namespace WzimTrainingClub.Controllers
{
    [Authorize]
    public class BodyweightController : Controller
    {
        private IBodyweightStorageService storageService;
        private UserManager<AppUser> userManager;

        public BodyweightController(IBodyweightStorageService StorageService, UserManager<AppUser> UserManager)
        {
            this.storageService = StorageService;
            this.userManager = UserManager;
        }

        private async Task<AppUser> GetUser()
        {
            return await userManager.GetUserAsync(HttpContext.User);
        }

        public async Task<IActionResult> Summary()
        {
            AppUser currentUser = await GetUser();

            IEnumerable<BodyweightRecord> records = await storageService.GetBodyweightRecords(currentUser);
            TargetBodyweight target = await storageService.GetTargetBodyweight(currentUser);

            BodyweightSummaryViewModel viewModel = new BodyweightSummaryViewModel(records, target);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditTarget()
        {
            AppUser currentUser = await GetUser();

            TargetBodyweight target = await storageService.GetTargetBodyweight(currentUser);

            return View(target);
        }

        [HttpPost]
        public async Task<IActionResult> EditTarget(float TargetWeight, DateTime TargetDate)
        {
            if (TargetWeight <= 0 || TargetWeight >= 200 || TargetDate <= DateTime.Today)
                return BadRequest();

            AppUser currentUser = await GetUser();


            TargetBodyweight newTarget = await storageService.GetTargetBodyweight(currentUser);
            if (newTarget == null)
            {
                newTarget = new TargetBodyweight()
                {
                    User = currentUser
                };
            }
            newTarget.TargetWeight = TargetWeight;
            newTarget.TargetDate = TargetDate;
            await storageService.StoreTargetBodyweight(newTarget);

            return RedirectToAction("Summary");
        }

        [HttpGet]
        public async Task<IActionResult> EditRecords()
        {
            AppUser currentUser = await GetUser();

            BodyweightRecord[] records = await storageService.GetBodyweightRecords(currentUser);

            return View(records);
        }

        [HttpPost]
        public async Task<IActionResult> EditRecords(DateTime[] Dates, float[] Weights)
        {
            if (Dates == null || Weights == null)
                return BadRequest();
            if (Dates.Length != Weights.Length)
                return BadRequest();

            for (int i = 1; i < Dates.Length; i++)
            {
                if (Weights[i] <= 0 || Weights[i] >= 200)
                    return BadRequest();
            }

            AppUser currentUser = await GetUser();

            await storageService.DeleteExistingRecords(currentUser);

            BodyweightRecord[] records = new BodyweightRecord[Dates.Length-1];
            for (int i = 1; i < Dates.Length; i++)
            {
                BodyweightRecord newRecord = new BodyweightRecord()
                {
                    User = currentUser,
                    Date = Dates[i],
                    Weight = Weights[i]
                };
                records[i-1] = newRecord;
            }

            await storageService.StoreBodyweightRecords(records);
            return RedirectToAction("Summary");
        }

        [HttpPost]
        public async Task<IActionResult> AddTodayWeight(float Weight)
        {
            if (Weight <= 0 || Weight >= 200)
                return BadRequest();

            AppUser currentUser = await GetUser();

            BodyweightRecord newRecord = new BodyweightRecord()
            {
                User = currentUser,
                Date = DateTime.Today,
                Weight = Weight
            };

            await storageService.StoreBodyweightRecord(newRecord);
            return RedirectToAction("Summary");
        }

        [HttpGet]
        public async Task<IActionResult> GetBodyweightData(int PreviousDays)
        {
            AppUser currentUser = await GetUser();

            BodyweightRecord[] records = await storageService.GetBodyweightRecords(currentUser, true);

            var result = records.Select(record => new { Date = record.Date.ToString("d"), Weight = record.Weight }).ToArray();

            return Json(result);
        }
    }
}

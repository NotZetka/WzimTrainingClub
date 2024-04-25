using WzimTrainingClub.Models;
using Microsoft.EntityFrameworkCore;

namespace WzimTrainingClub.Data
{
    public class BodyweightEFStorageService : IBodyweightStorageService
    {
        private ApplicationDbContext dbContext;

        public BodyweightEFStorageService(ApplicationDbContext DBContext)
        {
            this.dbContext = DBContext;
        }

        public async Task StoreBodyweightRecord(BodyweightRecord Record)
        {
            dbContext.BodyweightRecords.Add(Record);
            await dbContext.SaveChangesAsync();
        }

        public async Task StoreBodyweightRecords(IEnumerable<BodyweightRecord> Records)
        {
            dbContext.BodyweightRecords.AddRange(Records);
            await dbContext.SaveChangesAsync();
        }

        public async Task<BodyweightRecord[]> GetBodyweightRecords(AppUser User, bool AscendingOrder = false)
        {
            BodyweightRecord[] records = null;

            if (AscendingOrder == false)
            {
                records = await dbContext.BodyweightRecords
                    .Where(record => record.User == User)
                    .OrderByDescending(record => record.Date)
                    .ToArrayAsync();
            }
            else
            {
                records = await dbContext.BodyweightRecords
                    .Where(record => record.User == User)
                    .OrderBy(record => record.Date)
                    .ToArrayAsync();
            }

            return records;
        }

        public async Task<TargetBodyweight> GetTargetBodyweight(AppUser User)
        {
            TargetBodyweight result = await dbContext.TargetBodyweights.FirstOrDefaultAsync(target => target.User == User);
            if (result == null)
                return new TargetBodyweight();
            return result;
        }

        public async Task DeleteExistingRecords(AppUser User)
        {
            BodyweightRecord[] existingRecords = await dbContext.BodyweightRecords.Where(record => record.User == User).ToArrayAsync();
            dbContext.BodyweightRecords.RemoveRange(existingRecords);
            await dbContext.SaveChangesAsync();
        }

        public async Task StoreTargetBodyweight(TargetBodyweight Target)
        {
            if (Target.ID == 0)
                dbContext.TargetBodyweights.Add(Target);
            else
                dbContext.TargetBodyweights.Update(Target);

            await dbContext.SaveChangesAsync();


        }
    }
}

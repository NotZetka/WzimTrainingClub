using WzimTrainingClub.Models;

namespace WzimTrainingClub.Data
{
    public interface IBodyweightStorageService
    {
        public  Task<BodyweightRecord[]> GetBodyweightRecords(AppUser User, bool AscendingOrder = false);
        public Task<TargetBodyweight> GetTargetBodyweight(AppUser User);
        public Task StoreBodyweightRecord(BodyweightRecord Record);
        public Task StoreBodyweightRecords(IEnumerable<BodyweightRecord> Records);
        public Task DeleteExistingRecords(AppUser User);
        public Task StoreTargetBodyweight(TargetBodyweight Target);

    }
}

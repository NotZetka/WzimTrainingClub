using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WzimTrainingClub.Models;

namespace WzimFitnessApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<BodyweightRecord> BodyweightRecords { get; set; }
        public DbSet<TargetBodyweight> TargetBodyweights { get; set; }
        public DbSet<Food> UserFoods { get; set; }
        public DbSet<FoodRecord> FoodRecords { get; set; }
        public DbSet<DailyNutrition> DailyNutritions { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<WeightliftingGoal> WeightliftingGoals { get; set; }
        public DbSet<TimedGoal> TimedGoals { get; set; }
        public DbSet<GoalProgress> GoalProgressRecords { get; set; }
        public DbSet<WeightliftingGoalProgress> WeightliftingGoalProgresses { get; set; }
        public DbSet<TimedGoalProgress> TimedGoalProgresses { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FoodRecord>(entity =>
            {
                entity.HasOne(record => record.Food)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(record => record.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Food>(entity =>
            {
                entity.HasOne(food => food.CreatedBy)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientCascade);
            });

            builder.Entity<DailyNutrition>(entity =>
            {
                entity.HasOne(record => record.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}

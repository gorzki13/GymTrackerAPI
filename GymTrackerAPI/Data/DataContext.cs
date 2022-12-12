using GymTrackerAPI.models;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerAPI.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
       
        public DbSet<Exercise> Exercises => Set<Exercise>();
        public DbSet<Training> Trainings => Set<Training>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserData> UserData => Set<UserData>();
    }
}

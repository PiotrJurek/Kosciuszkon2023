using Microsoft.EntityFrameworkCore;

namespace LifeCrawler.Models
{
    public class Habit
    {
        public string habitId { get; set; }
        public string name { get; set; }
        public string? description { get; set; }
        public float frequency { get; set; }
        public bool suspended { get; set; }
        public float streak { get; set; }
        public bool isAntiHabit { get; set; }

        public Habit(string name, string? description, float frequency, bool isAntiHabit)
        {
            this.name = name;
            this.description = description;
            this.frequency = frequency;
            this.isAntiHabit = isAntiHabit;
            this.habitId = Guid.NewGuid().ToString();
            this.suspended = false;
            this.streak = 0;
        }
    }

    class HabitDb : DbContext
    {
        public HabitDb(DbContextOptions options) : base(options) { }
        public DbSet<Habit> Habits { get; set; } = null!;
    }
}


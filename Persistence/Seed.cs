using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Notes.Any()) return;
            
            var notes = new List<Note>
            {
                new Note
                {
                    Title = "Past Note 1",
                    Date = DateTime.UtcNow.AddMonths(-2),
                    Description = "Note 2 months ago",
                },
                new Note
                {
                    Title = "Past Note 2",
                    Date = DateTime.UtcNow.AddMonths(-1),
                    Description = "Note 1 month ago",
                },
                new Note
                {
                    Title = "Future Note 1",
                    Date = DateTime.UtcNow.AddMonths(1),
                    Description = "1 month in future",
                },
              
            };

            await context.Notes.AddRangeAsync(notes);
            await context.SaveChangesAsync();
        }
    }
}
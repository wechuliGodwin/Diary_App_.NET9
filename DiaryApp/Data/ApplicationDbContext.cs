using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //this is the table that will be created in the database
       public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry
                {
                    Id = 1,
                    Title = "Eating",
                    Content = "Went to eat choma.",
                    Created = new DateTime(2025, 08, 04, 12, 0, 0),
                },new DiaryEntry{ 
                    Id = 2,
                    Title = "Sleeping",
                    Content = "Went to sleep at 10pm.",
                    Created = new DateTime(2025, 08, 04, 13, 0, 0),
                }, new DiaryEntry
                {
                    Id = 3,
                    Title = "Waking up",
                    Content = "Woke up at 6am.",
                    Created = new DateTime(2025, 08, 04, 15, 0, 0),
                }
                );
        }

        //four steps to create a table in the database
        //1. Create a model class (DiaryEntry)
        //2. Create a Db set property in the ApplicationDbContext class (DiaryEntries)
        //3. add-migration AddDiaryEntryTable
        //4. update-database
    }
}

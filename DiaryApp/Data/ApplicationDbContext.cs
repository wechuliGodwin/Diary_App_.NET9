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
       
        //four steps to create a table in the database
        //1. Create a model class (DiaryEntry)
        //2. Create a Db set property in the ApplicationDbContext class (DiaryEntries)
        //3. add-migration AddDiaryEntryTable
        //4. update-database
    }
}

using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaryApp.Controllers
{
    public class DiaryEntriesController : Controller
    {
        // registered dbcontext in the constructor
        private readonly ApplicationDbContext _db;
        // constructor injection(Dependency Injection)
        public DiaryEntriesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // fetch all diary entries from the database
            List<DiaryEntry> entries = _db.DiaryEntries.ToList();
            return View(entries);
        }
        //display the create form
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]//annotate the below action for form submission
        public IActionResult Create(DiaryEntry obj)
        {
            _db.DiaryEntries.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}

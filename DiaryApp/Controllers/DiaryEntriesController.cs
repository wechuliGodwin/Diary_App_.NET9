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
            if (obj != null && obj.Title.Length < 3) {
                ModelState.AddModelError("Title", "title too short");
            }
            if (ModelState.IsValid) {
                _db.DiaryEntries.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
            //it will sent you back to the homecontoler index view.
        }


        public IActionResult Edit (int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            DiaryEntry diaryEntry = _db.DiaryEntries.Find(id);
            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }
        []
        public IActionResult Edit(DiaryEntry obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "title too short");
            }
            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "DiaryEntries");
            }
            return View();
            //it will sent you back to the homecontoler index view.
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            DiaryEntry diaryEntry = _db.DiaryEntries.Find(id);
            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }
        [HttpPost]
        public IActionResult Delete(DiaryEntry obj)
        {
               _db.DiaryEntries.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            //it will sent you back to the homecontoler index view.
        }

        //public IActionResult Create(DiaryEntry obj)
        //{
        //    _db.DiaryEntries.Add(obj);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index", "Home");//it will sent you back to the homecontoler index view.
        //}
    }
}

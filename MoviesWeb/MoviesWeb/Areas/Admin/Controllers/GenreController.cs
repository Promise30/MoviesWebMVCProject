using Microsoft.AspNetCore.Mvc;
using MoviesWeb.Data;
using MoviesWeb.Models;

namespace MoviesWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GenreController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Genre> objGenreList = _db.GenreTable.ToList();
            return View(objGenreList);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre obj)
        {
            if (ModelState.IsValid)
            {
                _db.GenreTable.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Genre entry created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Genre? genreFromDb = _db.GenreTable.Find(id);
            if (genreFromDb == null)
            {
                return NotFound();
            }
            return View(genreFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Genre obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Genre updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Genre? genreFromDb = _db.GenreTable.Find(id);
            if (genreFromDb == null)
            {
                return NotFound();
            }
            return View(genreFromDb);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeletePOST(int? id)
        {
            Genre? obj = _db.GenreTable.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.GenreTable.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Genre deleted successfully";
            return RedirectToAction("Index");

        }
    }
}

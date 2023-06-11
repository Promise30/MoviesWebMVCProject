using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesWeb.Data;
using MoviesWeb.Models;
using MoviesWeb.ViewModels;

namespace MoviesWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MovieController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;   
        }

        public IActionResult Index()
        {
            List<Movie> objMovieList = _db.MovieTable.Include(u => u.Genre).ToList();
         
            return View(objMovieList);

        }
        
        public IActionResult Create()
        {
            MovieVM movieVM = new()
            {
                GenreList = _db.GenreTable
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                Movie = new Movie()
            };
            
            return View(movieVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieVM movieVM)
        {
            if (ModelState.IsValid)
            {
                _db.MovieTable.Add(movieVM.Movie);
                _db.SaveChanges();
                TempData["success"] = "Movie entry created successfully";
                return RedirectToAction("Index");
            }
            else
            {

                movieVM.GenreList = _db.GenreTable.Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });
                return View(movieVM);
            }
            
        }
        public IActionResult Upsert(int? id)
        {
            MovieVM movieVM = new()
            {
                GenreList = _db.GenreTable
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                Movie = new Movie()
            };
            if (id == null || id == 0)
            {
                // Create
                return View(movieVM);
            }
            else
            {
                // Update
                movieVM.Movie = _db.MovieTable.Find(id);
                return View(movieVM);
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MovieVM movieVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string moviePath = Path.Combine(wwwRootPath, @"images\movies");


                    if(!string.IsNullOrEmpty(movieVM.Movie.ImageURL))
                    {
                        // Delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, movieVM.Movie.ImageURL.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(moviePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                   movieVM.Movie.ImageURL = @"\images\movies\" + fileName;
                }
                if(movieVM.Movie.Id == 0)
                {
                    _db.MovieTable.Add(movieVM.Movie);
                }
                else
                {
                    _db.MovieTable.Update(movieVM.Movie);
                }
                
                _db.SaveChanges();
                TempData["success"] = "Movie entry created successfully";
                return RedirectToAction("Index");
            }
            else
            {

                movieVM.GenreList = _db.GenreTable.Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });
                return View(movieVM);
            }

        }
        /*public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Movie? movieFromDb = _db.MovieTable.Find(id);
            if (movieFromDb == null)
            {
                return NotFound();
            }
            return View(movieFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Movie updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        */
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Movie? movieFromDb = _db.MovieTable.Find(id);
            if (movieFromDb == null)
            {
                return NotFound();
            }
            return View(movieFromDb);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeletePOST(int? id)
        {
            Movie? obj = _db.MovieTable.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.MovieTable.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Movie deleted successfully";
            return RedirectToAction("Index");

        }

        //#region API CALLS

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    List<Movie> objMovieList = _db.MovieTable.Include(u => u.Genre).ToList();
        //    return Json(new { data = objMovieList });
        //}

        //[HttpDelete]
        //public IActionResult Delete(int? id)
        //{
        //    var movieToBeDeleted = _db.MovieTable.Find(id);
        //    if(movieToBeDeleted == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting" });
        //    }

        //    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath,movieToBeDeleted.ImageURL.TrimStart('\\'));
        //    if (System.IO.File.Exists(oldImagePath))
        //    {
        //        System.IO.File.Delete(oldImagePath);
        //    }
        //    _db.MovieTable.Remove(movieToBeDeleted);
        //    _db.SaveChanges();
        //    return Json(new { success = true, message="Movie Deleted Successfully"});
        //}

        // #endregion
    }
}

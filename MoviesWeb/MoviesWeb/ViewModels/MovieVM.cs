using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWeb.Models;

namespace MoviesWeb.ViewModels
{
    public class MovieVM
    {
        public Movie Movie { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> GenreList { get; set; }
    }
}



using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWeb.Models
{
    public class Movie
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Director { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Range(0,10)]
        [Required]
        public decimal Rating { get; set; }
        //public List<Actor> Cast { get; set; }
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        [ValidateNever]
        public Genre Genre { get; set; }
        [ValidateNever]
        public string ImageURL { get; set; }
        
        
    }
}

using System.ComponentModel.DataAnnotations;

namespace MoviesWeb.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name="Date Created")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        
    }
}

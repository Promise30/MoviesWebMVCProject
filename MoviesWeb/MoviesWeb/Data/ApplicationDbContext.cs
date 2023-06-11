using Microsoft.EntityFrameworkCore;
using MoviesWeb.Models;

namespace MoviesWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Genre> GenreTable { get; set; }
        public DbSet<Movie> MovieTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //    modelBuilder.Entity<Category>().HasData(
            //        new Category { Id = 1, Name = "Action", DisplayOrder = 001 },
            //        new Category { Id = 2, Name = "SciFi", DisplayOrder = 002 },
            //        new Category { Id = 3, Name = "Drama", DisplayOrder = 003 });

            modelBuilder.Entity<Genre>().Property(e => e.CreationDate).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action", Description = "A popular movie genre characterised by thrilling, high-energy and adrenaline-pumping content." },
                new Genre { Id = 2, Name = "Comedy", Description = "A genre of film that aims to entertain and amuse the audience through humor and light-hearted storytelling." },
                new Genre { Id = 3, Name = "Sci-Fi", Description = "A genre of film that explores imaginative and speculative concepts often based on scientific and technological advancements." }


                );
            modelBuilder.Entity<Movie>().Property(e => e.ReleaseDate).HasColumnType("date");
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Teen Wolf",
                    Description = "A movie which revolves around the life of Scott Howard, a high school student who discovers he is a werewolf and has to deal with the challenges of balancing his newfound abilities with his everyday teenage life.",
                    Director = "Rod Daniel",
                    ReleaseDate = new DateTime(2011, 6, 5),
                    Rating = 8.0M,
                    GenreId = 1,
                    ImageURL = ""


                },
                new Movie
                {
                    Id = 2,
                    Title = "The Flash",
                    Description = "The series follows Barry Allen, a forensic scientist who gains superhuman speed after being struck by lightning and being exposed to chemicals in his lab.",
                    Director = "Greg Berlanti, Geoff Johns $ Andrew Kreisberg",
                    ReleaseDate = new DateTime(2014, 10, 7),
                    Rating = 8.5M,
                    GenreId = 3,
                    ImageURL= ""
                },
                new Movie
                {
                    Id = 3,
                    Title = "Everybody Hates Chris",
                    Description = "The series depicts the life, challenges and experiences of a young Chris Rock, growing up in the 1980s in a predominantly African-American neighbourhood of Brooklyn, New York.",
                    Director = "Chris Rock & Ali LeRoi",
                    ReleaseDate = new DateTime(2009, 5, 8),
                    Rating = 9.0M,
                    GenreId = 2,
                    ImageURL = "" 
                });


        }
    }
}

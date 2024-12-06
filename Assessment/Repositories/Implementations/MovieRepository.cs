using Assessment.Data;
using Assessment.DTOs.Get;
using Assessment.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Assessment.Repositories.Implementations
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AssessmentContext _context;

        public MovieRepository(AssessmentContext context)
        {
            _context = context;
        }

        public void AddMovie(MovieDTO movieDTO)
        {
            var newMovie = new Movie
            {
                Title = movieDTO.Title,
                ReleaseYear = movieDTO.ReleaseYear,
            };

            var existCatigory = _context.Categories
            .FirstOrDefault(c => c.Name == movieDTO.Category.Name);

            if (existCatigory != null)
                newMovie.CategoryId = existCatigory.Id;
            else
                newMovie.Category = new Category { Name = movieDTO.Category.Name };
            
            newMovie.Directors = new List<Director>();
            movieDTO.Directors.ForEach(d =>
            {
                newMovie.Directors.Add(
                    _context.Directors
                    .FirstOrDefault(x => x.Name == d.Name)
                    ?? new Director{
                        Name = d.Name,
                        Contact = d.Contact,
                        Email = d.Email,
                        Nationality = _context.Nationalities
                        .FirstOrDefault(n => n.Name == d.Nationality.Name) ??
                        new Nationality { Name = d.Nationality.Name },
                    });
            });

            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }

        /** Test CAses
        * Validate api [GET]'/api/movies' retrieves all movies with their associated directors and categories with natinality of director.
        * --- get by id
        * Validate api [GET'/api/movies/{id}]' responce with movie by spacific valid (exist) Id with it's associated directors and categories with natinality of director.
        * Validate api [GET]'/api/movies/{id}]' responce with NotFound status (404) if entered unvalid (not exist) id
        * --- add
        */
        public IEnumerable<MovieDTO> GetAllMoviesEager()
        {
            return _context.Movies
                .Include(m => m.Directors)
                    .ThenInclude(m => m.Nationality)
                .Include(m => m.Category)
                .Select(x => new MovieDTO
                {
                    Title = x.Title,
                    ReleaseYear = x.ReleaseYear,
                    Category = new CategoryDTO  {
                        Name = x.Category.Name,
                    },
                    Directors = x.Directors.Select(d => new DirectorDTO {
                        Name = d.Name,
                        Email = d.Email,
                        Contact = d.Contact,
                        Nationality = new NationalityDTO 
                            {
                              Name = d.Nationality.Name,
                            },
                        }).ToList(),
                })
                .ToList();
        }

        public MovieDTO GetMovieById(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Directors)
                    .ThenInclude(m => m.Nationality)
                .Include(m => m.Category)
                .FirstOrDefault(m => m.Id == id) ?? throw new Exception($"Movie With Id \'{id}\' not found");
            
            return new MovieDTO
                {
                    Title = movie.Title,
                    ReleaseYear = movie.ReleaseYear,
                    Category = new CategoryDTO
                    {
                        Name = movie.Category.Name,
                    },
                    Directors = movie.Directors.Select(d => new DirectorDTO
                    {
                        Name = d.Name,
                        Email = d.Email,
                        Contact = d.Contact,
                        Nationality = new NationalityDTO
                        {
                            Name = d.Nationality.Name,
                        },
                    }).ToList(),
                };
        }
    }
}

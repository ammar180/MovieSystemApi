using Assessment.Data;
using Assessment.DTOs.Get;
using Assessment.DTOs.Post;
using Assessment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Repositories.Implementations
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly AssessmentContext _context;

        public DirectorRepository(AssessmentContext context)
        {
            _context = context;
        }

        public void AddDirector(DirectorDTO directorDTO)
        {
            var newDirector = new Director
            {
                Name = directorDTO.Name,
                Email = directorDTO.Email,
                Contact = directorDTO.Contact,
            };
            var existNatinolity = _context.Nationalities
                        .FirstOrDefault(n => n.Name == directorDTO.Nationality.Name);
            if (existNatinolity != null)
                newDirector.NationalityId = existNatinolity.Id;
            else
                newDirector.Nationality = new Nationality { Name = directorDTO.Nationality.Name };

            _context.Directors.Add(newDirector);
            _context.SaveChanges();
        }

        public void RemoveDirector(int id)
        {
            var director = _context.Directors
                .FirstOrDefault(n => n.Id == id)
                ?? throw new NullReferenceException("Director Not found!");

            _context.Directors.Remove(director);
            _context.SaveChanges();
        }

        public void UpdateDirector(int id, DirectorDTO directorDTO, List<PostDirectorMovieDTO>? movieDTO)
        {
            var director = _context.Directors
                .Include(d => d.Movies)
                .Include(d => d.Nationality)
                .FirstOrDefault(n => n.Id == id) 
                ?? throw new NullReferenceException("Director Not found!");

            director.Name = directorDTO.Name;
            director.Email = directorDTO.Email;
            director.Contact = directorDTO.Contact;

            director.Movies = new List<Movie>();
            director.Movies = movieDTO?.Select(m => new Movie
            {
               Title = m.Title,
               ReleaseYear = m.ReleaseYear,
               Category = new Category { Name = m.Category.Name} ,
            }).ToList()?? new List<Movie>();

            director.Nationality = _context.Nationalities
                        .FirstOrDefault(n => n.Name == directorDTO.Nationality.Name) ??
                        new Nationality { Name = directorDTO.Nationality.Name };

            _context.Entry(director).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
